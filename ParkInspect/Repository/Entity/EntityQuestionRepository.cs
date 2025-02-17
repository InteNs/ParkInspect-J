﻿using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using Data;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;
using QuestionType = ParkInspect.Enumeration.QuestionType;

namespace ParkInspect.Repository.Entity
{
    public class EntityQuestionRepository : IQuestionRepository
    {
        private ObservableCollection<QuestionViewModel> _questions;
        private ObservableCollection<QuestionViewModel> _currentQuestions;
        private readonly ParkInspectEntities _context;

        public EntityQuestionRepository(ParkInspectEntities context)
        {
            _context = context;
            GetAll();
        }

        public ObservableCollection<QuestionViewModel> GetAll()
        {
            if (_questions == null) _questions = new ObservableCollection<QuestionViewModel>();
            _questions.Clear();

            var questions = _context.Question.Include("QuestionType");
            foreach (var questionDB in questions)
            {
                QuestionType result;
                Enum.TryParse(questionDB.QuestionType.Name, true, out result);

                if (!questionDB.IsActive) continue;
                _questions.Add(new QuestionViewModel()
                {
                    Id = questionDB.Id,
                    Version = questionDB.Version,
                    Description = questionDB.Description,
                    QuestionType = result
                });
            }
            RefreshCurrentQuestions();
            return _questions;
        }

        public bool Add(QuestionViewModel item)
        {
            var type = _context.QuestionType.FirstOrDefault(qt => qt.Name.Equals(item.QuestionType.ToString()));
            if (type == null) return false;
            var calculatedId = (_context.Question.Max(q => q.Id) + 1);
            var question = new Question()
            {
                Id = calculatedId,
                QuestionTypeId = type.Id,
                Description = item.Description,
                Version = 1,
                IsActive = true,
                Guid = new Guid(),
                QuestionTypeGuid = type.Guid
            };
            _context.Question.Add(question);
            _context.SaveChanges();
            item.Id = question.Id;
            _questions.Add(item);
            _currentQuestions.Add(item);
            return true;
        }

        public bool Delete(QuestionViewModel item)
        {
            var question =
                _context.Question.Include("QuestionType")
                    .FirstOrDefault(q => q.Id == item.Id && q.Version == item.Version);
            if (question == null) return false;
            question.IsActive = false;
            _context.Entry(question).State = EntityState.Modified;
            _context.SaveChanges();
            _currentQuestions.Remove(item);
            return true;
        }

        public bool Update(QuestionViewModel item)
        {
            var question =
                _context.Question.Include("QuestionType")
                    .FirstOrDefault(q => q.Id == item.Id && q.Version == item.Version);
            if (question == null) return false;

            var type = _context.QuestionType.FirstOrDefault(qt => qt.Name.Equals(item.QuestionType.ToString()));
            if (type == null) return false;

            var questionCopy = new Question
            {
                Description = item.Description,
                Version = question.Version + 1,
                Guid = Guid.NewGuid(),
                Id = question.Id,
                IsActive = question.IsActive,
                QuestionTypeId = type.Id,
                QuestionTypeGuid = type.Guid
            };

            question.IsActive = false;
            _context.Question.Add(questionCopy);
            _context.SaveChanges();
            item.Version = item.Version + 1;
            RefreshCurrentQuestions();
            return true;
        }

        public ObservableCollection<QuestionViewModel> GetLatest()
        {
            RefreshCurrentQuestions();
            return _currentQuestions;
        }

        private void RefreshCurrentQuestions()
        {
            if (_currentQuestions == null) _currentQuestions = new ObservableCollection<QuestionViewModel>();
            _currentQuestions.Clear();

            foreach (var questionViewModel in _questions.Where(q => !(from qq in _questions
                where qq.Id == q.Id && qq.Version > q.Version
                select qq).Any()))
            {
                _currentQuestions.Add(questionViewModel);
            }
        }
    }
}

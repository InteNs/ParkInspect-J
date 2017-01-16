using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkInspectPortal.Models;
using Data;

namespace ParkInspectPortal.Repositories
{
    public class InspectionRepo:IInspectionRepo
    {
        public List<InspectionViewModel> GetInspections()
        {
            List<InspectionViewModel> Inspections = new List<InspectionViewModel>();
            using (var ctx = new ParkInspectEntities())
            {
                var inspections = ctx.Inspection.ToList();
                foreach (var item in inspections)
                    Inspections.Add(new InspectionViewModel()
                    {
                        DateTimeEnd = item.DateTimeEnd,
                        DateTimeStart = item.DateTimeStart,
                        Guid = item.Guid,
                        Id = item.Id,
                    });
            }
            return Inspections;
        }

        public List<QuestionListViewModel> GetQuestionList(Guid guid)
        {
            List<QuestionListViewModel> list = new List<QuestionListViewModel>();
            using (var ctx = new ParkInspectEntities())
            {
                var questionList = ctx.QuestionList.Where(q => q.Guid == guid).FirstOrDefault();

                if (questionList == null)
                    return null;

                var questionItems = ctx.QuestionItem.Where(q => q.QuestionListId == questionList.Id).ToList();

                foreach (var item in questionItems)
                {
                    try
                    {
                        list.Add(new QuestionListViewModel()
                        {
                            Question =
                                ctx.Question.Where(q => q.Id == item.QuestionId && q.Version == item.QuestionVersion)
                                    .FirstOrDefault()
                                    .Description,
                            Answer =  ctx.Answer.Where(q=>q.Id == item.AnswerId).FirstOrDefault().Value
                        });
                    }
                    catch (Exception e)
                    {
                        
                    }
                }

            }

            return list;
        }
    }
}
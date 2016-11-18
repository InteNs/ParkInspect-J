# ParkInspect

## Regels

### Git regels

De master branch bevat een volledig werkend project.

De development branch is de plaats waar alle feature branches samen worden gevoegd om een werkend product te krijgen.

#### Milestones

Een milestone is een verzameling van taken die als een geheel gezien worden. Een milestone bevat meerdere taken, en een deadline
er kunnen meerdere mensen aan een dezelfde milestone werken.

#### Issues

Issues zijn alle taken die nodig zijn om een milestone te voltooien, de omvang van een issue is klein, en wordt door een persoon uitgevoerd, als een issue is opgelost wordt dat door middel van een pull request geclosed, dus niet handmatig.

#### Branches

een branch dient als een plek waar de code komt te staan om een bepaalde issue op te lossen de naamgeving voor zo'n branch is
```
feature/dit-is-een-feature
```
denk hierbij aan kleine letters en streepjes!

#### Pull requests

een pull request is een aanvraag om jouw code in te leveren. een pull request hangt dus aan een issue.
als je een pull request aanmaakt, link dan naar de bijbehorende issue dmv `closes #4` of `resolves #4` of `fixes #4` waar #4 de referentie is naar de issue.

#### Commits

commits zijn een verzameling van changes, geef de commit message een duidelijke beschrijving van wat de changes zijn, in het engels

probeer te zorgen dat commits onafhankelijk zijn van elkaar


### Code regels
#### Structuur
##### Views
de views moeten zo veel mogelijk voldoen aan de wireframes
##### ViewModels
de structuur van de viewmodels is als volgt:

1. private fields
2. properties
3. constructors
4. public methods
5. private methods

#### Patterns

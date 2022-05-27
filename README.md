# AQA_Lab_Final_Project
AQA Project
e2e tests for Github Application functionality.

=====================================================================================================================
Application
URL: https://github.com/

=====================================================================================================================

Create test cases in qase.io management systems and get approve from mentor.  
Implement Automation framework for testing of TestRail API and UI.
Setup Jenkins job to trigger automation test run at 11 AM each day. 
At the end of each run allure report should be generated.

What must be:

- [ ] At least 7 e2e tests
- [ ] At least 5 API tests
- [ ] At least 2 Data-driven tests
- [ ] API calls for precondition steps
- [ ] Clearing of test data after launching a specific test / suite / test run (should be decided by AQA Engineer)
- [ ] Readable and understandable Allure report
- [ ] Code conventions 

Tech Stack:

- [ ] .NET Core 
- [ ] Nunit 
- [ ] Selenium
- [ ] Fluent Assertions 
- [ ] RestSharp
- [ ] GIT
- [ ] AllureReports
- [ ] Jenkins

Patterns that should be used in ATF:

- [ ] Factory
- [ ] Chain of invocations
- [ ] Decorator
- [ ] Mediator 


=====================================================================================================================

Git strategy 

- [ ] main — main branch 
- [ ] develop — the main development branch. Each commit to the develop branch is a result of a feature development completion. Each commit should be a result of a merge of merge request from a feature branch.
- [ ] feature — each new feature should reside in its own branch, which is created off of the latest develop version. When a feature is complete, it gets merged back into develop via merge request. After the feature branch is deleted.

Branch Names Convention 

feature/case—id-new-awesome-feature

Each commit message should be in the format:

CASE-ID: Title starting with a capital letter



GOOD LUCK!
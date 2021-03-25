Feature: LoanApplication
	In Order for me to buy posche
	As a cash poor customer
	I need to get a loan

Scenario: Application submitted successfully
	Given I am on the loan application page
		And I enter a first name of Sarah
		And I enter a last name of Sanders
		And I select that I have an existing loan application
		And I confirm my acceptance of the terms and conditions
	When I submit the application
	Then I should see the application complete confirmation page for Sarah

Scenario: Cannot submit application unless T&C are accepted
	Given I am on the loan application page
		And I enter a first name of James
		And I enter a last name of Cook
		And I select that I have an existing loan application
	When I submit the application
	Then I should see an error message telling me that I must accept terms and conditions
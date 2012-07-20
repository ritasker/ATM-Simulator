Feature: Logging In
	So I don't have to wait inline at the Bank
	As a ATM account holder
	I should be able to login to my account farm an ATM

Scenario: Entering a valid account number
	Given the ATM has £1000 in it
	And the following bank accounts have been setup:
		| Account Number | PIN  | Balance | Overdraft Limit |
		| 0123456789     | 1337 | 100     | 250             |
	When I enter the following account number and PIN:
		| Account Number | PIN  |
		| 0123456789     | 1337 |
	Then I should be allowed into the system

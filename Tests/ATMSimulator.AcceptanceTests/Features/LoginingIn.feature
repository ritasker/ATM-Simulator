Feature: Logging In
	So I don't have to wait inline at the Bank
	As a ATM account holder
	I should be able to login to my account farm an ATM

Background:
	Given the ATM has £1000 in it
	And the following bank accounts have been setup:
		| Account Number | PIN  | Balance | Overdraft Limit |
		| 0123456789     | 1337 | 100     | 250             |

Scenario: Entering a valid account number	
	When I enter my account number '0123456789'
	And my pin '1337'
	Then I should see the menu screen

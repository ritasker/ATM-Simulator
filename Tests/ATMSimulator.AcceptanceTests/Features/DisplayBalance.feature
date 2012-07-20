Feature: Dispaly Balance
	So I don't have to wait inline at the Bank
	As a ATM account holder
	I should be able to check my balance from an ATM

Scenario: Display Balence
	Given the ATM has £1000 in it
	And the following bank accounts have been setup:
		| Account Number | PIN  | Balance | Overdraft Limit |
		| 0123456789     | 1337 | 100     | 250             |
	When I request to see my balance for my account '0123456789'
	Then I should see my balance as £100
	And I should see my available funds as £350

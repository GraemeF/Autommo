Feature: Movement
	In order to do interact with the world
	As a bot
	I want to move around it

Scenario: Track movement progress
	Given I am positioned at 0,0,0
	When I move to 100,0,0
	And I wait for 2 seconds
	Then I should be moving

Scenario: Move to a location
	Given I am positioned at 0,0,0
	When I move to 10,0,0
	And I wait for 2 seconds
	Then I should be positioned at 10,0,0

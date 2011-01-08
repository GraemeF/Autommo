Feature: Survey
	In order to see what is in the game world
	As a player
	I want to see what is around my character

Scenario: Get list of nearby mobs
	When I ask what is near my character
	Then the response should include a nearby mob

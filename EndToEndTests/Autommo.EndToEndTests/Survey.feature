Feature: Survey
	In order to see what is in the game world
	As a player
	I want to see what is around my character

Scenario: See if there are any mobs in the neighbourhood
	When I ask what is near my character
	Then there should be a mob in the neighbourhood

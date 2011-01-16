Feature: Admin
	In order to edit the world
	As an administrator
	I want to change what is in it

Scenario: Add a new character
	When I add character "Bob" to the world
	Then I can get the character "Bob"

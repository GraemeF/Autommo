Feature: Combat
	In order to win epic loot
	As a bot
	I want to kill things

Scenario: Enter combat
	Given there is a hostile mob
	When I move my character next to the mob
	Then combat should begin

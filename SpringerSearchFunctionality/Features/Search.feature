Feature: Search
	In order to avoid silly mistakes
	As a Springer User
	I want to user search functionality

@UI
Scenario: Search Functionality Agile Keyword
	Given That I am on home page and have a word to search
	When I type "Agile" in search box 
	And Click search button
	Then Books related to "Agile" will appear in search result 


@UI
Scenario: Search Functionality Computer Keyword
	Given That I am on home page and have a word to search
	When I type "Computer" in search box 
	And Click search button
	Then Books related to "Computer" will appear in search result 


@UI
Scenario: Search Functionality No Keyword supplied
	Given That I am on home page and have a word to search
	When I type "" in search box 
	And Click search button
	Then Books related to "" will appear in search result 

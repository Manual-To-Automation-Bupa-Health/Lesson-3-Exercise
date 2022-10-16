Feature: Add Products

A short summary of the feature

@tag1
Scenario: Add products to cart
	Given I am currently on the homepage "https://automationexercise.com/"
	When I click on the Products menu item
	When I add a product to the cart
	Then I should see one product in my cart
	When I add another product to the cart
	Then I should see two products in my cart\

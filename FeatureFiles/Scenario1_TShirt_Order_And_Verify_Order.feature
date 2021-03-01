Feature: Orders
	1. Launch browser and navigate to the application
	2. Login to my store application
	3. Order T-Shirt
	4. Pay by bank wire payment option
	5. Validate the order reference number, order date, order total price & order payment type on Order history screen
	6. Go to home page & close browser

@OrdersTest
Scenario: Order T-Shirt and verify in order history
	When I launch the browser and navigate to "My Store" application
	Then I should see "Landing" page
	When I click on "Sign In" button on "Landing" page
	Then I should see "Login" page
	When I enter sign in details in "Login" page and click on "Sign In" button
	Then I should see "Home" page
	When I click on "TShirts" button on "Home" page
	Then I should see "TShirts" page
	When I click on "Add To Cart" button on "TShirts" page
	Then I should see "Summary" page
	And The total item price should be equal to the sum of item price, shipping price and tax on "Summary" page
	When I click on "Proceed To Checkout" button on "Summary" page
	Then I should see "Address" page
	When I click on "Proceed To Checkout" button on "Address" page
	Then I should see "Shipping" page
	And The shipping price on "Shipping" page should be equal to the shipping price shown on summary page
	When I fill all the mandatory details on "Shipping" page and click on "Proceed To Checkout" button
	Then I should see "Payment" page
	And  I should get the same total price on "Payment" page as schown on summary page
	When I click on "Pay By Bank Wire" link on "Payment" page
	Then I should see "Order Summary" page
	When I click on "I Confirm My Order" link on "Order Summary" page
	Then I should see "Order Confirmation" page
	And  I should get the order reference of the item on "Order Confirmation" page
	When I click on "Back To Orders" link on "Order Confirmation" page
	Then I should see "Order History" page
	And I should see the same order reference on "Order History" page that is shown on order confirmation page
	When I click on "Home" link on "Order History" page
	Then I should see "Home" page
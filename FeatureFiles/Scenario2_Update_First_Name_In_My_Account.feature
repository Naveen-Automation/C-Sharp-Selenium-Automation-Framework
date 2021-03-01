Feature: Updates
	1. Launch browser and navigate to the application
	2. Login to my store application
	3. Update personal information (first name) and save it
	4. Verify the success message & first name
	5. Close browser

@UpdateTest
Scenario: Update personal information and verify on home page
	When I launch the browser and navigate to "My Store" application
	Then I should see "Landing" page
	When I click on "Sign In" button on "Landing" page
	Then I should see "Login" page
	When I enter sign in details in "Login" page and click on "Sign In" button
	Then I should see "Home" page
	When I click on "My Personal Information" button on "Home" page
	And I key the below details in "My Personal Information" screen and I click on "Save" button
		| FirstName |
		| Veeranki  |
	Then I should see a success message on "My Personal Information" screen
# Trapped in a cabin with Lord Byron - the Java Version

## What you will need
- Java 21 or higher
- Maven 3.8.X or higher
- Git
- an IDE could be useful (but you can use VI, I don't mind)

## How to proceed
- Fork this repository
- Checkout
- Take a look at the [rules](../Rules.md) (keep it opened somewhere)
- Take a look inside directory `src/test/java/fr/eulbobo/dojo/byron/domain`
- Proceed in alphabetical order (trust me on that one)
- Start coding

## Useful commands
You can build, launch test and generate code coverage report by running `mvn verify` 

Code coverage report is generated in `target/jacoco/index.html` (this will only generate if all tests are green)

## Any tips ?
Depending on your setup, you may first need to create all classes / interfaces as empty shells to allow project compilation. Watch out for your IDE trying to be smart (it is not smart enough).

A example output of the previous project can be found in the file named [output.txt](../output.txt).
Some things in this log are not in the tests, meaning that you should not implement them :
- Displaying each of the dice roll result
- Displaying the number of rounds at the end
- Displaying the end score
# How to install this custom template
***

> clone the repo on your local machine and in the root of the template project 
>open your console and type:

`dotnet new --install .`

>this will install the template in your local machine to use it everytime
>in case you need to update the template for changes in the main repo, to re install it type:

`dotnet new --install . --force`

##How to use the template in your machine 
>after installed the template in your machine you can go to an specific folder to create a new project,
>open your console and type:

#help
`dotnet new custom-web-api --help`


#example of domain: Customer
`dotnet new custom-web-api -o "nameOfYourNewAPI" -do "nameOfYourDomain"`

>this will create the project with all the project references needed with the standards of Clean Architecture
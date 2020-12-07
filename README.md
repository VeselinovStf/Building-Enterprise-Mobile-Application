# Building-Enterprise-Mobile-Application
Pluralsight "Building an Enterprise Mobile Application with Xamarin.Forms" course repository

### Course Info

- Xamarin.Forms is Microsoft's recommended way of building mobile, cross-platform applications. This course will teach you how to build mobile applications for the enterprise with the MVVM pattern, dependency injection, commanding, testing, and more.

- Xamarin.Forms is the preferred way for Microsoft developers to build applications that run on Android, iOS, and Windows. To use Xamarin.Forms for real applications that meet today’s requirements for flexibility and testability, you need to structure code according to industry-standard architecture guidelines. In this course, Building an Enterprise Mobile Application with Xamarin.Forms, you will learn how a real-life application is built with Xamarin.Forms. First, you will see a proposed architecture that promotes code-reuse as well as testability and maintainability. Next, you will learn how MVVM can be used in Xamarin.Forms. Then, you will create loose-coupling through messaging patterns and dependency injection, which are integrated in the proposed architecture. By the end of this course, you will have a good understanding of a real-life application architecture for Xamarin.Forms applications. 

## Pluralsights 'Building Cross-platform Apps with Xamarin Forms' Path
- At its simplest, Xamarin.Forms is a mobile application framework for building user interfaces.

## Advanced Course
- Continue learning about Xamarin with these courses which will cover advanced topics such as incorporating Google Maps, localization, and Enterprise Xamarin.

### Content

- Course Overview
- Introduction
- Creating a Layered Architecture
- Applying the MVVM Pattern
- Creating Loose Coupling Through Dependency Injection
- Communicating Components Through Messaging
- Setting up Navigation and Dialogs Within the Application
- Accessing Native Device Features and Controls
- Testing the Setup with Unit Tests

### Course Duration: 3h 1m

### Status

- Complete

# Course Project Info

## Course Start up project
- Provided Backend REST API - Bethany's Pie Shop - Catalog API

### Catalog HTTP API Endpoints

#### Authentication

- [POST] /api/Authentication/Authenticate
- [POST] /api/Authentication/Register

#### Catalog

- [GET] /api/Catalog/Pies
- [GET] /api/Catalog/PiesOfTheWeek
- [GET] /api/Catalog/pies/{id}

#### Contact

- [POST] /api/Contact

#### Order

- [POST] /api/Order

#### ShoppingCart

- [GET] /api/ShoppingCart/{userId}
- [POST] /api/ShoppingCart

## Assignment Scenario

-  Build an application for Bethany who runs a great little pie shop in Belgium. Bethany bakes the most delicious pies and after having a new website, she also now needs to have a mobile application. Bethany is very tech savvy and she thinks that very soon customers of hers will be placing orders via her mobile application. Create a mobile application for both iOS and Android. In the application, users can browse the catalog, place an order, send feedback, or make a phone call directly from the application. We decided to build this application with Xamarin. Forms. 

## Tasks

- Build Mobile application
- Users can browse catalog
- Users can place orders
- Users can give feedback
- Users can call store from application
- Users must authenticate

## Project Architecture Goals

- Separation of concerns
- Testability
- Maintainability
- Loose coupling
- Code share

## Project Structure

#### Services

- BethanysPieShop.API - Backend API

#### Mobile

- BethanysPieShop.Core - Share .NET Standart 2.0 Code
- BethanysPieShop.Droid - Android App 
- BethanysPieShop.Core - iOS App

#### Test

- BethanysPieShop.UnitTests - Shared Code Unit Tests




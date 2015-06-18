# GDLibrary
LIbrary providing easy access to the Google Directions API from a .NET applicaton.   Provideed as a Class Library (GDConsumer) and a test harness Console App (GDHarness).  

HOWTO

--- OPTIONAL---
This first step is entirely optional - you can use the API console and that way you can track your API requests - however this is a public API and as such it doesn't need you to authenticate at this time - perhaps in the future it will do.  So details are here for clarity.

1/ Create API Key in Developer Console
Goto: console.developers.google.com
Add a new application
In APIs enable the Directions API
In Credentials create a "New Key" - then create a Server Key

Remember you are limited to 2,500 requests per day.
--- /OPTIONAL----


Calling the API is described here (and below including sample urls)
https://developers.google.com/maps/documentation/directions/

The API only needs a GET Request.

Sample URL: https://maps.googleapis.com/maps/api/directions/json?origin=<POSTCODE>&destination=<POSTCODE>
(replace <POSTCODE1> with your source postcode, and <POSTCODE2> with your destination postcode.

So base URL is https://maps.googleapis.com/maps/api/directions/json (the json is there to ensure the results are in json otherwise its XML which is evil and we don't want that!!

?origin=   This is your starting point (postcodes are fine)
?destination=    This is the end point  (postcodes are fine)

===OPTIONAL===
?key=    This is the API key -this is optional and doesn't need to be set
===/OPTIONAL===

Other optional params are:

?mode= this defaults to driving but can be driving, walking, bicycling, transit (not available everywhere for all locations)

?waypoints= this allows you to specify an array of waypoints to be used on the route - not necessarily required

?alternatives= if this is set to true, this tells the directions service that it may provide more than 1 route alternative in the response - this will generally make the response slow and shouldn't be used unless absolutely required.

?avoid= this lets you specify the type of routes to avoid - can be supplied as a pipe delimited list of the following tolls, highways, ferries

?language= provides the ability to grab the directions in other languages.  a list of languages and codes can be found here https://developers.google.com/maps/faq#languagesupport

?units= specifies the unit system when displaying results - valid systems are metric (kilometres and meters) and imperial (miles and feet)

?region= specifies the region code as a top level domain two value character - for a full list see: https://developers.google.com/maps/documentation/directions/#RegionBiasing

?departure_time= - specifies a desired departure time (since this api caters for traffic conditions where available), this should be specified as an integer in seconds since midnight (00:00 January 1 1970 UTC), a value of "now" can also be specified which sets the departure time to the current time - accurate to the latest second

?arrival_time= specifies the desired arrival time in seconds since midnight Jan 1 1970 UTC.

NOTE: you can specify either arrival_time or departure_time - BUT NOT BOTH

?transit_mode= this can be provided as a pipe delimited list of possible transit (public transport) types from the list bus, subway, train, tram, rail - again not relevant for us.

?transit_routing_preferences= provides certain preferences for transit routes, can be either less_walking or fewer_transfers

The optional params are not really required, and the results we are looking for will be found in the resultant

GoogleDirectionsResultObject.routes.legs[x].distance.value which will give a value in meters, this can then be simply converted to miles or kilometres as required.

Be weary - if more than 1 leg is returned, you will need to aggregate the legs and add the distances together.

You can check the number of legs returned, if > 1 - then you need to add the multiple leg distances together - otherwise you can just use the single leg - generally legs will always only have one item - however if you set ?alternatives=true - you will possibly get more than 1 route - which will result in more than 1 leg.

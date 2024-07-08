This API allows you to manage tickets, patients, and doctor schedules. Below are the available endpoints:

Endpoints
Get Tickets by Date
Retrieve tickets for a specific date.

Request
URL: /tickets
Method: GET
Query Parameters:
date (DateTime, required) - The date for which to retrieve tickets.
Responses
200 OK - Returns a list of tickets for the specified date.
400 Bad Request - Returns an error message if the date parameter is invalid.
Add Patient
Add a new patient to the system.

Request
URL: /patients
Method: POST
Body Parameters:
firstName (string, required) - The first name of the patient.
lastName (string, required) - The last name of the patient.
dateOfBirth (DateTime, required) - The date of birth of the patient.
phone (string, required) - The phone number of the patient.
email (string, required) - The email address of the patient.
Responses
200 OK - Indicates the patient was successfully added.
400 Bad Request - Returns validation errors if the input data is invalid.
500 Internal Server Error - Returns an error message if an exception occurred while adding the patient.
Get Tickets by Patient
Retrieve tickets for a specific patient.

Request
URL: /patients/{patientId}/tickets
Method: GET
Path Parameters:
patientId (int, required) - The ID of the patient.
Responses
200 OK - Returns a list of tickets for the specified patient.
400 Bad Request - Returns an error message if the patient ID is invalid.

Get Tickets by Doctor
Retrieve tickets for a specific doctor.

Request
URL: /doctors/{doctorId}/tickets
Method: GET
Path Parameters:
doctorId (int, required) - The ID of the doctor.
Responses
200 OK - Returns a list of tickets for the specified doctor.
400 Bad Request - Returns an error message if the doctor ID is invalid.
404 Not Found - Returns an error message if no tickets are found for the specified doctor.

Get Doctor Schedule
Retrieve the schedule for a specific doctor.

Request
URL: /doctors/{doctorId}/schedule
Method: GET
Path Parameters:
doctorId (int, required) - The ID of the doctor.
Responses
200 OK - Returns the schedule for the specified doctor.
400 Bad Request - Returns an error message if the doctor ID is invalid.

Get Doctor Specializations
Retrieve all doctors and their specializations.

Request
URL: /doctors/specializations
Method: GET
Responses
200 OK - Returns a list of doctors and their specializations.
Error Handling
In case of an error, the API will return an appropriate status code and an error message.

Common Error Responses
400 Bad Request: The request contains invalid parameters.
500 Internal Server Error: An unexpected error occurred on the server.

Conclusion
This documentation provides details about the available endpoints in the Hospital API, including request parameters, response types, and example requests and responses. Use this information to interact with the API effectively.

# Code Review

- [ ] Ensure that all the API URLs have been reviewed by peers (i.e., other teams and/or the API team)
  - [ ] No camelCase in the URLs but Dashes API-RM-005
  - [ ] URIs are REST based and not SOA based (i.e., no "method" endpoints like "/getOrderById")
  - [ ] URIs have the correct plurality API-RM-001 (ask yourself, "What is the Resource?")

# Testing

- [ ] All APIs should have the proper Unit Testing with Mocks
- [ ] Ensure the Unit Tests are Unit Tests and not Integration Tests
- [ ] Ensure all Integration Tests are incorporated into the API
  - [ ] Work with the Test Automation Team if needed
- [ ] Update QA Postman Collections API Postman Collections (https://legalzoom.atlassian.net/wiki/spaces/QA/pages/126386251/API+Postman+Collections)

# Documentation

- [ ] Ensure the API has a Swagger Page, and the Swagger Page is in the Documentation
- [ ] Ensure the Swagger Page has the proper Description for every Endpoint.  For example the **"Gets a new Session ID"** description
- [ ] Confluence API Page (with proper use of Template & Confluence Labels)
  - [ ] Port Number (not feature port) is correctly identified on the Confluence Page
  - [ ] The Main "API" Confluence Space should show the API listed.  If this is not showing up check the Main API Page's Label's.
- [ ] Confluence API Endpoint Pages (with proper use of Template & Confluence Tags)
  - [ ] If setup correctly, the specific API Page should show the list of endpoints
- [ ] The README.md page updated in the GitHub Repository
  - [ ] Link to Confluence Page
  - [ ] Link to Development Swagger page
  - [ ] Link to Monitoring /uptime endpoint
  - [ ] Any other additional info that is helpful the APIs (i.e., Dependencies, etc)


# Backend API Versioning

- [ ] <VersionPrefix> is added to the Service Host layer ".csproj" file

	> **Versioning is based on the Semantic Versioning and follows the format of Major.Minor.Patch. Patch increments indicate backwards compatibility.**

# Security

- [ ] Ensure any OAuth works for the API if applicable
- [ ] Ensure endpoints have the necessary Applications associated/added in Apigee
- [ ] If endpoints can be tied to a Customer ID, ensure there is Resource Authorization on the Customer ID
- [ ] If endpoints can be tied to an Order ID, ensure there is Resource Authorization on the Order ID

# Monitoring

- [ ] The API has a monitoring endpoint "/uptime"
- [ ] The API has a monitoring endpoint "/databases"
- [ ] The API has a monitoring endpoint "/internal-services"
- [ ] The API has a monitoring endpoint "/external-services"
- [ ] Add the specific monitoring endpoints to the "LZ API Monitoring" Application in Apigee
  - [ ] Communication for Apigee changes is in the RID for release to Production
- [ ] All monitoring endpoints are added to Nagios.  Work with the NOC team to get this established:
  - [ ] Endpoint for /uptime are added to Nagios
  - [ ] Endpoint for /internal-services are added to Nagios
  - [ ] Endpoint for /databases are added to Nagios
  - [ ] Endpoint for /external-services are added to Nagios
  - [ ] Endpoint for each, individual, Server are added to Nagios
    - [ ] DEV - laiw12ap517d
    - [ ] QA - laiw12ap518q
    - [ ] STG1 - laiw12ap527s
    - [ ] STG2 - laiw12ap537s
    - [ ] PROD1 - laiw12ap528p
    - [ ] PROD2 - laiw12ap538p
    - [ ] PROD3 - laiw12ap544p
    - [ ] PROD4 - laiw12ap545p
  - [ ] Endpoint for each DNS are added to Nagios
    - [ ] apidev.legalzoom.com
    - [ ] apidev-internal.legalzoom.com
    - [ ] apiqa.legalzoom.com
    - [ ] apiqa-internal.legalzoom.com
    - [ ] apistg.legalzoom.com
    - [ ] apisstg-internal.legalzoom.com
    - [x] api.legalzoom.com
    - [ ] api-internal.legalzoom.com


# Network Operations Center (NOC)

- [ ] Create Run Books for Starting/Stopping/Restarting the APIs
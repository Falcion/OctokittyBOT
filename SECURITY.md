# Security policy

This document provides information on the safety of using the bot and its direct policy.

## Safety Use

This open source project is not responsible for any users or their actions related to this program. Under any circumstances at the time of security breaches or other types of security breaches, contact the user of the program himself.

Also, this project is not responsible for any types of data that it receives from user input: this applies to all types of such situations. Please only use the bot for a safe purpose that does not violate GitHub policies.

## Vulnerabilities in Stratum

Stratum is a heavy bot in its understanding, which uses and is limited to third-party libraries. It's possible that Stratum or its dependent libraries contain vulnerabilities that would allow triggering unexpected or dangerous behavior with specially inputs.

### Vulnerability

Given Stratum's flexibility, it's possible to specify args which exhibit unexpected or unwanted behavior. The fact that Stratum creates requests to GitHub API and Discord API at one time means that it may use your token on maximum potential: reading repository's data, creating special requests, read third-party data. It's only when these behaviors are outside the specifications of the operations involved that such behavior is a vulnerability.

As a general rule, it is incorrect behavior for Stratum to access context it doesn't own, or to terminate in an unclean way. Bugs in Stratum that lead to such behaviors constitute a vulnerability.

One of the most critical parts of any system is input handling. If malicious input can trigger side effects or incorrect behavior, this is a bug, and likely a vulnerability.

### Reporting vulnerabilities

Please email reports about any security related issues you find to `falcionml@gmail.com` and use a descriptive subject line for your report email.

In addition, please include the following information along with your report:

* Your name and affiliation (if any).
* A description of the technical details of the vulnerabilities. It is very important to let me know how we can reproduce your findings.
* An explanation who can exploit this vulnerability, and what they gain when doing so - write an attack scenario. This will help me evaluate your report quickly, especially if the issue is complex.
* Whether this vulnerability public or known to third parties. If it is, please provide details.

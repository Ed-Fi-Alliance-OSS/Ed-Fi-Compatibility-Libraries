# Ed-Fi-Compatibility-Libraries

[![OpenSSF Scorecard](https://api.securityscorecards.dev/projects/github.com/Ed-Fi-Alliance-OSS/Ed-Fi-Compatibility-Libraries/badge)](https://securityscorecards.dev/viewer/?uri=github.com/Ed-Fi-Alliance-OSS/Ed-Fi-Compatibility-Libraries)

Shared libraries for backward compatibility support

## Developer Notes

* Although this is called "53" it applies to ODS/API 5.4 as well.
* Running the integration tests requires presence of SQL Server and PostgreSQL
  instances with the EdFi_Security database from 5.3 or 5.4.
* Release process does not match our ideal scenario in other repositories.
  * Create a Pre-release
  * Automatically builds and publishes a NuGet package with the version number
    from `Directory.Build.props`
  * If everything looks good, then change to a release, and
  * In Azure Artifacts, promote the new NuGet package to the Release view.

## Legal Information

Copyright (c) 2023 Ed-Fi Alliance, LLC and contributors.

Licensed under the [Apache License, Version 2.0](LICENSE) (the "License").

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

See [NOTICES](NOTICES.md) for additional copyright and license notifications.

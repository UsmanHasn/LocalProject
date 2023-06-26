- To Add Migration

* Add-Migration mingrationname

- To Generate script

* Script-Migration -Idempotent -Output Pathtosave.sql -from LastExecutedMigration -to NewMigration

For Example:
Initial Create is last migration which was already executed
AddColumns is current updates

Then, command would be 

* Script-Migration -Idempotent -Output Pathtosave.sql -from InitialCreate -to AddColumns
 
It will generate script after initialcreate modification till add columns modification
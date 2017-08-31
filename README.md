# HelloDynamo
Example of custom Dynamo nodes.
Contains:
- custom NodeModel node
- custom UI NodeModel node

![image](https://cloud.githubusercontent.com/assets/2679513/16582748/be9e36e4-42a8-11e6-8c0a-429c0caf0ef1.png)

### Documentation
More info on custom nodes on the [Dynamo Wiki](https://github.com/DynamoDS/Dynamo/wiki/How-To-Create-Your-Own-Nodes) or [Dynamo Premier](http://dynamoprimer.com/).

### Debug

To debug change your StartAction to: `C:\Program Files\Dynamo\Dynamo Revit\1.0\DynamoSandbox.exe`.
The project has post build actions set to:

```
xcopy /Y "$(TargetDir)*.*" "$(AppData)\Dynamo\Dynamo Core\1.3\packages\$(ProjectName)\bin\"
xcopy /Y "$(ProjectDir)pkg.json" "$(AppData)\Dynamo\Dynamo Core\1.3\packages\$(ProjectName)"
```

Change accordingly if using another version of Dynamo.


![image](http://i.imgur.com/ZKfnm2e.png)

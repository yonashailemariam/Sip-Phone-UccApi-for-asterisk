Build :
1. Open an MSBUILD command window. 
2. Change directory to the sources directory of this sample
3. Run the build command: 
MSBUILD IMVoIPSample.csproj 

Executing:
1. After building the EXE will be placed in bin\debug
2. CD to the bin\debug directory
3. Execute the IMVoIPSample.exe

Notes:

1. Above steps may not work if you have copied the sample code from the installation directory to some other directory. If so, you will need to manually copy all the dll files included with the SDK to the appropriate folders.

2. Above steps may not work on Windows Vista if you have User Access Control feature enabled.

3. If you want to create a Visual Studio project for this sample, create an empty project and add all files other than IMVoIPSample.csproj file. You will also need to add a reference to UCCPLib.dll in your project. You should also set the "Copy to Output Directory" property to "Copy Always" for the following files to  in Visual Studio: IMVoIPSample.exe.manifest, config.xml and all dll files.

4. The logout functionality implemented in this sample has the minimum functionality necessary to demonstrate logging out of Office Communications Server. In consequence, The memory management requirements of a production application have not been addressed in the sample code. For information about logging out of Office Communications Server and avoiding memory leaks, refer to the SDK documentation.



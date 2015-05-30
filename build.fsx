#r "tools/FAKE/tools/FakeLib.dll"

open Fake

let buildDir = "build"

Target "Deps" (fun _ ->
    RestorePackages()
)

Target "Clean" (fun _ -> 
    ignore(Shell.Exec("git", "clean -x -d -f"))
)

Target "BuildApp" (fun _ ->
    !! "src/**/*.csproj"
    |> MSBuildRelease buildDir "Build"
    |> Log "AppBuild-Output: "
)

Target "Test" (fun _ ->  
    !! ("src/**/*.Test.dll")
        |> NUnit (fun p -> 
            {p with
                DisableShadowCopy = true; 
            })
)

// Build order
"Clean"
  ==> "Deps"
  ==> "BuildApp"
  ==> "Test"

RunTargetOrDefault "Test"
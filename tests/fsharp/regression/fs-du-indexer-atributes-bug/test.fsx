(*****************  Repro for issue#5713 ---- https://github.com/Microsoft/visualfsharp/issues/5713      *****************)
(*
    When the bug was present we saw this error:

    Runtime error:
    System.Reflection.TargetParameterCountException: Parameter count mismatch.
       at System.Reflection.RuntimeMethodInfo.InvokeArgumentsCheck(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
       at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
       at System.Reflection.RuntimePropertyInfo.GetValue(Object obj, BindingFlags invokeAttr, Binder binder, Object[] index, CultureInfo culture)
       at Microsoft.FSharp.Reflection.Impl.getUnionCaseRecordReader@290.Invoke(Object obj)
       at Microsoft.FSharp.Reflection.FSharpValue.GetUnionFields(Object value, Type unionType, FSharpOption`1 bindingFlags)
       at Microsoft.FSharp.Text.StructuredPrintfImpl.ReflectUtils.Value.GetValueInfoOfObject$cont@434(BindingFlags bindingFlags, Object obj, Type reprty, Unit unitVar)
       at Microsoft.FSharp.Text.StructuredPrintfImpl.ReflectUtils.Value.GetValueInfoOfObject(BindingFlags bindingFlags, Object obj)
       at Microsoft.FSharp.Text.StructuredPrintfImpl.ReflectUtils.Value.GetValueInfo[a](BindingFlags bindingFlags, a x, Type ty)
       at Microsoft.FSharp.Text.StructuredPrintfImpl.Display.anyL[a](ShowMode showMode, BindingFlags bindingFlags, FormatOptions opts, a x, Type ty)
       at Microsoft.FSharp.Text.StructuredPrintfImpl.Display.anyToStringForPrintf[T](FormatOptions options, BindingFlags bindingFlags, T value, Type x_1)
       at Microsoft.FSharp.Core.PrintfImpl.ObjectPrinter.GenericToStringCore[T](T v, FormatOptions opts, BindingFlags bindingFlags)
       at Microsoft.FSharp.Core.PrintfImpl.GenericToString@1106-3.Invoke(T v)
       at Microsoft.FSharp.Core.PrintfImpl.FinalFast1@262.Invoke(FSharpFunc`2 env, A a)
       at <StartupCode$FSI_0002>.$FSI_0002.main@()
    Stopped due to error

    Expected behavior
        STDOUT: T 1

*)

//module TestOfFsiPrinting =
System.Diagnostics.Debugger.Launch();;
System.Diagnostics.Debugger.Break();;
type Piesek = Kotek of int
with
    member __.Item with get(i:int) = ()
System.Diagnostics.Debugger.Break();;
let x = Kotek 1;;
printfn "%A" x;;

System.IO.File.WriteAllText("test.ok","ok");;
printfn "Succeeded";;

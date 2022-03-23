Option Strict Off
Imports System
Imports NXOpen

Module NXJournal
    Sub Main(ByVal args() As String)

        Dim a(,) As Double = {{0.85, 30.16, 12.84, 4.09, 0.83, 0.75},
        {0.41, 41.09, 11.91, 4.34, 1.02, 1.04},
        {0.86, 64.53, 6.28, 3.59, 1.19, 0.9},
        {0.8, 33.28, 3.47, 4.41, 0.91, 0.93},
        {0.67, 28.59, 7.84, 4.78, 0.74, 1.11},
        {0.72, 69.22, 9.72, 4.28, 0.86, 1.08},
        {0.89, 62.97, 5.97, 3.41, 0.88, 1.19},
        {0.78, 39.53, 6.91, 4.66, 1.18, 0.77},
        {0.58, 37.97, 3.78, 4.97, 0.85, 0.71},
        {0.77, 45.78, 11.28, 3.03, 0.82, 1.02},
        {0.61, 27.03, 9.41, 3.09, 1.15, 0.88},
        {0.83, 23.91, 5.34, 3.91, 0.77, 0.85},
        {0.52, 36.41, 4.09, 3.97, 1.16, 1.07},
        {0.74, 53.59, 9.09, 3.53, 1.0, 0.72},
        {0.88, 61.41, 3.16, 4.53, 1.08, 0.91},
        {0.53, 48.91, 7.22, 3.78, 0.9, 0.83},
        {0.5, 66.09, 8.47, 4.84, 1.1, 1.1},
        {0.75, 52.03, 8.16, 4.16, 0.72, 1.18},
        {0.55, 31.72, 10.34, 3.34, 1.13, 0.86},
        {0.63, 55.16, 12.22, 3.66, 0.75, 0.74},
        {0.6, 22.34, 10.97, 3.16, 0.8, 0.8},
        {0.64, 56.72, 5.03, 4.91, 1.04, 1.15},
        {0.45, 59.84, 6.59, 3.72, 1.11, 0.79},
        {0.81, 42.66, 8.78, 4.03, 0.94, 0.97},
        {0.7, 58.28, 12.53, 3.22, 0.99, 0.82},
        {0.66, 50.47, 10.03, 4.22, 1.07, 0.96},
        {0.44, 47.34, 5.66, 4.72, 0.93, 0.94},
        {0.56, 34.84, 7.53, 3.47, 0.97, 1.0},
        {0.42, 44.22, 4.72, 4.59, 0.79, 1.05},
        {0.69, 67.66, 10.66, 3.84, 0.96, 0.99},
        {0.47, 20.78, 4.41, 4.47, 1.05, 1.13},
        {0.49, 25.47, 11.59, 3.28, 0.71, 1.16}}

        Dim n = 32

        Dim theSession As NXOpen.Session = NXOpen.Session.GetSession()
        Dim workPart As NXOpen.Part = theSession.Parts.Work

        Dim displayPart As NXOpen.Part = theSession.Parts.Display


        Dim i
        For i = 0 To (n - 1)

            Dim exportPath
            Dim modelID
            modelID = a(i, 0) & "-" & a(i, 1) & "-" & a(i, 2) & "-" & a(i, 3) & "-" & a(i, 4) & "-" & a(i, 5)
            exportPath = "D:\FILES\Project\20220227-FilmSampleAutoGenerate\01-model\" & modelID & ".prt"



            ' ----------------------------------------------
            '   Menu: Tools->Expressions...
            ' ----------------------------------------------
            theSession.Preferences.Modeling.UpdatePending = False

            Dim expressionGroups1() As NXOpen.ExpressionGroup
            expressionGroups1 = workPart.ExpressionGroups.GetAllExpressionGroupsInPart()

            Dim expressionGroup1 As NXOpen.ExpressionGroup
            expressionGroup1 = workPart.ExpressionGroups.Active

            Dim expressionGroups2() As NXOpen.ExpressionGroup
            expressionGroups2 = expressionGroup1.GetMemberGroups()

            Dim expressionGroup2 As NXOpen.ExpressionGroup
            expressionGroup2 = workPart.ExpressionGroups.Active

            workPart.ExpressionGroups.Active = expressionGroup2

            Dim markId1 As NXOpen.Session.UndoMarkId
            markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Expression")

            Dim expression1 As NXOpen.Expression = CType(workPart.Expressions.FindObject("alpha"), NXOpen.Expression)

            Dim unit1 As NXOpen.Unit = CType(workPart.UnitCollection.FindObject("Degrees"), NXOpen.Unit)

            workPart.Expressions.EditWithUnits(expression1, unit1, a(i, 1))

            Dim expressionGroups3() As NXOpen.ExpressionGroup
            expressionGroups3 = workPart.ExpressionGroups.GetAllExpressionGroupsInPart()

            Dim expressionGroup3 As NXOpen.ExpressionGroup
            expressionGroup3 = workPart.ExpressionGroups.Active

            Dim expressionGroups4() As NXOpen.ExpressionGroup
            expressionGroups4 = expressionGroup3.GetMemberGroups()

            Dim expressionGroup4 As NXOpen.ExpressionGroup
            expressionGroup4 = workPart.ExpressionGroups.Active

            workPart.ExpressionGroups.Active = expressionGroup4

            Dim expression2 As NXOpen.Expression = CType(workPart.Expressions.FindObject("Df"), NXOpen.Expression)

            Dim unit2 As NXOpen.Unit = CType(workPart.UnitCollection.FindObject("MilliMeter"), NXOpen.Unit)

            workPart.Expressions.EditWithUnits(expression2, unit2, a(i, 0))

            Dim expressionGroups5() As NXOpen.ExpressionGroup
            expressionGroups5 = workPart.ExpressionGroups.GetAllExpressionGroupsInPart()

            Dim expressionGroup5 As NXOpen.ExpressionGroup
            expressionGroup5 = workPart.ExpressionGroups.Active

            Dim expressionGroups6() As NXOpen.ExpressionGroup
            expressionGroups6 = expressionGroup5.GetMemberGroups()

            Dim expressionGroup6 As NXOpen.ExpressionGroup
            expressionGroup6 = workPart.ExpressionGroups.Active

            workPart.ExpressionGroups.Active = expressionGroup6

            Dim expression3 As NXOpen.Expression = CType(workPart.Expressions.FindObject("Hjet"), NXOpen.Expression)

            workPart.Expressions.EditWithUnits(expression3, unit2, a(i, 5))

            Dim expressionGroups7() As NXOpen.ExpressionGroup
            expressionGroups7 = workPart.ExpressionGroups.GetAllExpressionGroupsInPart()

            Dim expressionGroup7 As NXOpen.ExpressionGroup
            expressionGroup7 = workPart.ExpressionGroups.Active

            Dim expressionGroups8() As NXOpen.ExpressionGroup
            expressionGroups8 = expressionGroup7.GetMemberGroups()

            Dim expressionGroup8 As NXOpen.ExpressionGroup
            expressionGroup8 = workPart.ExpressionGroups.Active

            workPart.ExpressionGroups.Active = expressionGroup8

            Dim expression4 As NXOpen.Expression = CType(workPart.Expressions.FindObject("Hout"), NXOpen.Expression)

            workPart.Expressions.EditWithUnits(expression4, unit2, a(i, 4))

            Dim expressionGroups9() As NXOpen.ExpressionGroup
            expressionGroups9 = workPart.ExpressionGroups.GetAllExpressionGroupsInPart()

            Dim expressionGroup9 As NXOpen.ExpressionGroup
            expressionGroup9 = workPart.ExpressionGroups.Active

            Dim expressionGroups10() As NXOpen.ExpressionGroup
            expressionGroups10 = expressionGroup9.GetMemberGroups()

            Dim expressionGroup10 As NXOpen.ExpressionGroup
            expressionGroup10 = workPart.ExpressionGroups.Active

            workPart.ExpressionGroups.Active = expressionGroup10

            Dim expression5 As NXOpen.Expression = CType(workPart.Expressions.FindObject("Pc"), NXOpen.Expression)

            Dim nullNXOpen_Unit As NXOpen.Unit = Nothing

            workPart.Expressions.EditWithUnits(expression5, nullNXOpen_Unit, a(i, 3))

            Dim expressionGroups11() As NXOpen.ExpressionGroup
            expressionGroups11 = workPart.ExpressionGroups.GetAllExpressionGroupsInPart()

            Dim expressionGroup11 As NXOpen.ExpressionGroup
            expressionGroup11 = workPart.ExpressionGroups.Active

            Dim expressionGroups12() As NXOpen.ExpressionGroup
            expressionGroups12 = expressionGroup11.GetMemberGroups()

            Dim expressionGroup12 As NXOpen.ExpressionGroup
            expressionGroup12 = workPart.ExpressionGroups.Active

            workPart.ExpressionGroups.Active = expressionGroup12

            Dim expression6 As NXOpen.Expression = CType(workPart.Expressions.FindObject("Sc"), NXOpen.Expression)

            workPart.Expressions.EditWithUnits(expression6, nullNXOpen_Unit, a(i, 2))

            Dim expressionGroups13() As NXOpen.ExpressionGroup
            expressionGroups13 = workPart.ExpressionGroups.GetAllExpressionGroupsInPart()

            Dim expressionGroup13 As NXOpen.ExpressionGroup
            expressionGroup13 = workPart.ExpressionGroups.Active

            Dim expressionGroups14() As NXOpen.ExpressionGroup
            expressionGroups14 = expressionGroup13.GetMemberGroups()

            Dim expressionGroup14 As NXOpen.ExpressionGroup
            expressionGroup14 = workPart.ExpressionGroups.Active

            workPart.ExpressionGroups.Active = expressionGroup14

            theSession.Preferences.Modeling.UpdatePending = False

            Dim markId2 As NXOpen.Session.UndoMarkId
            markId2 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Update Expression Data")

            Dim expressionGroups15() As NXOpen.ExpressionGroup
            expressionGroups15 = workPart.ExpressionGroups.GetAllExpressionGroupsInPart()

            Dim expressionGroup15 As NXOpen.ExpressionGroup
            expressionGroup15 = workPart.ExpressionGroups.Active

            Dim expressionGroups16() As NXOpen.ExpressionGroup
            expressionGroups16 = expressionGroup15.GetMemberGroups()

            Dim expressionGroup16 As NXOpen.ExpressionGroup
            expressionGroup16 = workPart.ExpressionGroups.Active

            workPart.ExpressionGroups.Active = expressionGroup16

            Dim nErrs1 As Integer
            nErrs1 = theSession.UpdateManager.DoUpdate(markId2)

            theSession.DeleteUndoMark(markId2, "Update Expression Data")

            theSession.Preferences.Modeling.UpdatePending = False

            Dim markId3 As NXOpen.Session.UndoMarkId
            markId3 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Update Expression Data")

            Dim nErrs2 As Integer
            nErrs2 = theSession.UpdateManager.DoUpdate(markId3)

            theSession.DeleteUndoMark(markId3, "Update Expression Data")

            ' ----------------------------------------------
            '   Menu: File->Save As...
            ' ----------------------------------------------
            Dim partSaveStatus1 As NXOpen.PartSaveStatus
            partSaveStatus1 = workPart.SaveAs(exportPath)

            partSaveStatus1.Dispose()

        Next

    End Sub
End Module
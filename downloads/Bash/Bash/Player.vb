Public Class Player
    Inherits System.Windows.Forms.Form

    'Player.vb

    'make machines
    Private Boat As New Machine(False)
    Private Airplane As New Machine(True)
    Private Ship As New Machine(False)
    Private Helicopter As New Machine(True)

    'attack variables
    Private Strike(512) As Point

    'nuke variables
    Private NukeStrike(512) As Point
    Private NukeTarget As Point
    Private Nuke As Boolean = True
    Private Nuking As Boolean = False

    'other variables
    Private Target As Point
    Private i As Integer = 0
    Private newround As Boolean = True
    Private BaseX As Integer

    'constructor
    Sub New(ByVal xstart As Integer)
        BaseX = xstart
    End Sub

    'accessor methods
    Function getBoat() As Machine
        Return Boat
    End Function

    Function getAirplane() As Machine
        Return Airplane
    End Function

    Function getShip() As Machine
        Return Ship
    End Function

    Function getHelicopter() As Machine
        Return Helicopter
    End Function

    Function getTarget() As Point
        Return Target
    End Function

    Function getTargetX() As Integer
        Return Target.X
    End Function

    Function getTargetY() As Integer
        Return Target.Y
    End Function

    Function getLineStrike() As Point()
        Return Strike
    End Function

    Function getNukeStrike() As Point()
        Return NukeStrike
    End Function

    Function getNukeTarget() As Point
        Return NukeTarget
    End Function

    Function hasNuke() As Boolean
        Return Nuke
    End Function

    Function ifNuking() As Boolean
        Return Nuking
    End Function

    Function getBaseX() As Integer
        Return BaseX
    End Function

    Function getBaseRect() As Rectangle

        Dim rect As New Rectangle(10, 225, 25, 25)

        Return rect

    End Function

    Function getNewRound() As Boolean
        Return newround
    End Function

    'mutator methods
    Function setTarget(ByVal X As Integer, ByVal Y As Integer) As Integer
        Target = New Point(X, Y)
    End Function

    Function setNukeTarget(ByVal X As Integer, ByVal Y As Integer) As Integer
        NukeTarget = New Point(X, Y)
    End Function

    Function setNuke(ByVal has As Boolean)
        Nuke = has
    End Function

    Function setNuking(ByVal test As Boolean)
        Nuking = test
    End Function

    Function setNewRound(ByVal nr As Boolean) As Integer
        newround = nr
    End Function

    Function setBaseX(ByVal value As Integer) As Integer
        BaseX = value
    End Function

    Function resetI() As Integer
        i = 0
    End Function

    'helper methods
    Function createPointsOnLine(ByVal X As Integer, ByVal Y As Integer, ByVal draw As Boolean) As Point()

        If draw Then
            Strike(i) = New Point(X, Y)
            i += 1
        End If
        If (Nuking) Then
            NukeStrike(i) = New Point(X, Y)
            i += 1
        End If

    End Function

    Function ClearLineStrikeOfNull() As Integer
        Dim j As Integer

        For j = 0 To Strike.Length - 1
            If (Strike(j).X = 0 And Strike(j).Y = 0) Then
                Strike(j).X = Target.X
                Strike(j).Y = Target.Y
            End If
        Next

    End Function

    Function ClearLineNukeStrikeOfNull() As Integer
        Dim j As Integer

        For j = 0 To NukeStrike.Length - 1
            If (NukeStrike(j).X = 0 And NukeStrike(j).Y = 0) Then
                NukeStrike(j).X = NukeTarget.X
                NukeStrike(j).Y = NukeTarget.Y
            End If
        Next

    End Function

    Function ClearLineNukeStrikeOfTarget() As Integer
        Dim j As Integer

        For j = 0 To NukeStrike.Length - 1
            If (NukeStrike(j).X = Target.X And NukeStrike(j).Y = Target.Y) Then
                NukeStrike(j).X = 0
                NukeStrike(j).Y = 0
            End If
        Next

    End Function

    Function clearStrike() As Integer
        Strike.Clear(Strike, 0, Strike.Length)

    End Function

    Function HitOrMiss(ByVal opposingTarget As Point) As Boolean

        If (HitOrMissOnPoints(opposingTarget)) Then
            Return True
        End If
        If (HitOrMissOnHalfPoints(opposingTarget)) Then
            Return True
        End If

        Return False
    End Function

    Private Function HitOrMissOnPoints(ByVal opposingTarget As Point) As Boolean
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim windisplayed As Boolean = False

        For i = -2 To 2
            For j = -2 To 2
                For k = 0 To Strike.Length - 1
                    If (opposingTarget.X + i = Strike(k).X And opposingTarget.Y + j = Strike(k).Y) Then
                        If windisplayed = False Then
                            Return True
                        Else
                            'null
                        End If
                    End If
                Next
            Next
        Next

        Return False
    End Function

    Private Function HitOrMissOnHalfPoints(ByVal opposingTarget As Point) As Boolean
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim windisplayed As Boolean = False

        For i = -2 To 2
            For j = -2 To 2
                For k = 0 To Strike.Length - 1
                    If (Not (k = 512)) Then
                        If (opposingTarget.X + i = ((Strike(k).X + Strike(k + 1).X) / 2) And opposingTarget.Y + j = ((Strike(k).Y + Strike(k + 1).Y) / 2)) Then
                            If windisplayed = False Then
                                Return True
                            Else
                                'null
                            End If
                        Else
                            If (opposingTarget.X + i = Strike(k).X And opposingTarget.Y + j = Strike(k).Y) Then
                                If windisplayed = False Then
                                    Return True
                                Else
                                    'null
                                End If
                            End If
                        End If
                    End If
                Next
            Next
        Next

        Return False
    End Function

    Function HitOrMissNuke(ByVal opposingTarget As Point) As Boolean

        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim windisplayed As Boolean = False

        For i = -6 To 6
            For j = -6 To 6
                For k = 0 To NukeStrike.Length - 1
                    If (opposingTarget.X + i = NukeStrike(k).X And opposingTarget.Y + j = NukeStrike(k).Y) Then
                        If windisplayed = False Then
                            Return True
                        Else
                            'null
                        End If
                    End If
                Next
            Next
        Next

        Return False
    End Function

    Function StrikeOffPage() As Boolean

        Dim i As Integer

        For i = 0 To Strike.Length - 1
            If (Strike(i).X < 0 Or Strike(i).X > 800 Or Strike(i).Y < 0 Or Strike(i).Y > 600) Then
                Return True
            End If
        Next

        Return False

    End Function

End Class

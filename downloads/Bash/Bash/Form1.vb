Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents tmrTurn As System.Windows.Forms.Timer
    Friend WithEvents frmMenu As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents About As System.Windows.Forms.MenuItem
    Friend WithEvents Credits As System.Windows.Forms.MenuItem
    Friend WithEvents AttackTimer As System.Windows.Forms.MenuItem
    Friend WithEvents FourthSecond As System.Windows.Forms.MenuItem
    Friend WithEvents HalfSecond As System.Windows.Forms.MenuItem
    Friend WithEvents OneSecond As System.Windows.Forms.MenuItem
    Friend WithEvents tmrDraw As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.tmrDraw = New System.Windows.Forms.Timer(Me.components)
        Me.tmrTurn = New System.Windows.Forms.Timer(Me.components)
        Me.frmMenu = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.AttackTimer = New System.Windows.Forms.MenuItem
        Me.FourthSecond = New System.Windows.Forms.MenuItem
        Me.HalfSecond = New System.Windows.Forms.MenuItem
        Me.OneSecond = New System.Windows.Forms.MenuItem
        Me.About = New System.Windows.Forms.MenuItem
        Me.Credits = New System.Windows.Forms.MenuItem
        '
        'tmrDraw
        '
        Me.tmrDraw.Enabled = True
        Me.tmrDraw.Interval = 500
        '
        'tmrTurn
        '
        Me.tmrTurn.Enabled = True
        Me.tmrTurn.Interval = 250
        '
        'frmMenu
        '
        Me.frmMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.About})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.AttackTimer})
        Me.MenuItem1.Text = "Game"
        '
        'AttackTimer
        '
        Me.AttackTimer.Index = 0
        Me.AttackTimer.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.FourthSecond, Me.HalfSecond, Me.OneSecond})
        Me.AttackTimer.Text = "Attack Timer"
        '
        'FourthSecond
        '
        Me.FourthSecond.Checked = True
        Me.FourthSecond.Index = 0
        Me.FourthSecond.Text = "1/4 Second"
        '
        'HalfSecond
        '
        Me.HalfSecond.Index = 1
        Me.HalfSecond.Text = "1/2 Second"
        '
        'OneSecond
        '
        Me.OneSecond.Index = 2
        Me.OneSecond.Text = "1 Second"
        '
        'About
        '
        Me.About.Index = 1
        Me.About.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.Credits})
        Me.About.Text = "About"
        '
        'Credits
        '
        Me.Credits.Index = 0
        Me.Credits.Text = "Credits"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Cursor = System.Windows.Forms.Cursors.Cross
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.frmMenu
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bash"

    End Sub

#End Region

    'Bash Version 1.0.5
    'Form1.vb

    'PATCHESI INCLUDED IN VERSION 1.0.4
    '-added icon
    '-added other main window settings
    '-added a crosshair for mouse icon

    'PATCHESI INCLUDED IN VERSION 1.0.3
    '-added game bar at top

    'PATCHES INCLUDED IN VERSION 1.0.2
    '-Aadded comments and made private variables

    'PATCHES INCLUDED IN VERSION 1.0.1
    '-added nuke

    'player objects
    Private Player1 As New Player(10)
    Private Player2 As New Player(755)

    'island
    Private Island As Rectangle

    'pen objects
    Private RedPen As New Pen(Color.Red) 'player 1's color
    Private BluePen As New Pen(Color.Blue) 'player 2's color

    'brush objects
    Private RedBrush As New SolidBrush(Color.Red)
    Private BlueBrush As New SolidBrush(Color.Blue)
    Private GreenBrush As New SolidBrush(Color.Green)
    Private OrangeBrush As New SolidBrush(Color.Orange)

    'booleans
    Private blnDraw As Boolean = False
    Private newgame As Boolean = True
    Private player1turn As Boolean = True
    Private ifdrewisland As Boolean = False

    'mouse input
    Private mousex As Integer
    Private mousey As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown

        If e.Button = MouseButtons.Left Then

            mousex = e.X
            mousey = e.Y
            tmrTurn.Enabled = True

            If (player1turn = True) Then

                If ((mousex >= 10 And mousex <= 35) And (mousey >= 342 And mousey <= 368)) Then

                    If (Player1.hasNuke) Then
                        MakeOtherPlayerTargetBig(Player2.getTarget)
                        Player1.setNuking(True)
                        Player1.setNuke(False)
                    End If

                Else
                    If (Player1.getNewRound = True) Then
                        If ((mousex >= 10 And mousex <= 35) And (mousey >= 225 And mousey <= 329)) Then
                            If (setMachineInPlay(mousex, mousey)) Then
                                blnDraw = True
                                Player1.setNewRound(False)
                            End If
                        Else
                            blnDraw = False

                        End If
                    Else
                        If ((mousex >= Player1.getTargetX - 2 And mousex <= Player1.getTargetX + 2) And (mousey >= Player1.getTargetY - 2 And mousey <= Player1.getTargetY + 2)) Then
                            blnDraw = True
                        Else
                            blnDraw = False

                        End If
                    End If
                End If

            End If

            If (player1turn = False) Then



                If ((mousex >= 755 And mousex <= 780) And (mousey >= 342 And mousey <= 368)) Then

                    If (Player2.hasNuke) Then
                        MakeOtherPlayerTargetBig(Player1.getTarget)
                        Player2.setNuking(True)
                        Player2.setNuke(False)
                    End If

                Else
                    If (Player2.getNewRound = True) Then
                        If ((mousex >= 755 And mousex <= 780) And (mousey >= 225 And mousey <= 329)) Then
                            If (setMachineInPlay(mousex, mousey)) Then
                                blnDraw = True
                                Player2.setNewRound(False)
                            End If
                        Else
                            blnDraw = False

                        End If
                    Else
                        If ((mousex >= (Player2.getTargetX - 2)) And (mousex <= (Player2.getTargetX + 2)) And (mousey >= (Player2.getTargetY - 2)) And (mousey <= (Player2.getTargetY + 2))) Then
                            blnDraw = True
                        Else
                            blnDraw = False

                        End If
                    End If
                End If

            End If

        End If

    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove

        If blnDraw = True Then
            If player1turn = True Then
                Player1.createPointsOnLine(e.X, e.Y, True)
            Else
                Player2.createPointsOnLine(e.X, e.Y, True)
            End If
        End If

        If (Player1.ifNuking) Then
            Player1.createPointsOnLine(e.X, e.Y, False)
        End If
        If (Player2.ifNuking) Then
            Player2.createPointsOnLine(e.X, e.Y, False)
        End If


    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp

        Dim objGraphic As Graphics = CreateGraphics()
        Dim ifdrew As Boolean = False

        If (blnDraw = True) Then
            ifdrew = True
        Else
            Player1.resetI()
            Player2.resetI()
        End If

        If (Player1.ifNuking) Then
            Player1.setNukeTarget(e.X, e.Y)
            Player1.ClearLineNukeStrikeOfNull()
            objGraphic.DrawCurve(RedPen, Player1.getNukeStrike)
            If (Player1.HitOrMissNuke(Player2.getTarget)) Then
                If (Player2.getBoat.getInPlay) Then
                    objGraphic.FillRectangle(BlueBrush, 755, 225, 25, 25)
                    Player2.getBoat.setDestroy(True)
                    Player2.getBoat.setInPlay(False)
                End If
                If (Player2.getAirplane.getInPlay) Then
                    objGraphic.FillRectangle(BlueBrush, 755, 251, 25, 25)
                    Player2.getAirplane.setDestroy(True)
                    Player2.getAirplane.setInPlay(False)
                End If
                If (Player2.getShip.getInPlay) Then
                    objGraphic.FillRectangle(BlueBrush, 755, 277, 25, 25)
                    Player2.getShip.setDestroy(True)
                    Player2.getShip.setInPlay(False)
                End If
                If (Player2.getHelicopter.getInPlay) Then
                    objGraphic.FillRectangle(BlueBrush, 755, 303, 25, 25)
                    Player2.getHelicopter.setDestroy(True)
                    Player2.getHelicopter.setInPlay(False)
                End If
                Player2.setNewRound(True)
                Call PlaySoundWicked()
            End If
            Player1.setNuking(False)
            objGraphic.FillRectangle(RedBrush, 10, 342, 25, 25)
        Else
            Player1.resetI()
        End If
        If (Player2.ifNuking) Then
            Player2.setNukeTarget(e.X, e.Y)
            Player2.ClearLineNukeStrikeOfNull()
            objGraphic.DrawCurve(BluePen, Player2.getNukeStrike)
            If (Player2.HitOrMissNuke(Player1.getTarget)) Then
                If (Player1.getBoat.getInPlay) Then
                    objGraphic.FillRectangle(RedBrush, 10, 225, 25, 25)
                    Player1.getBoat.setDestroy(True)
                    Player1.getBoat.setInPlay(False)
                End If
                If (Player1.getAirplane.getInPlay) Then
                    objGraphic.FillRectangle(RedBrush, 10, 251, 25, 25)
                    Player1.getAirplane.setDestroy(True)
                    Player1.getAirplane.setInPlay(False)
                End If
                If (Player1.getShip.getInPlay) Then
                    objGraphic.FillRectangle(RedBrush, 10, 277, 25, 25)
                    Player1.getShip.setDestroy(True)
                    Player1.getShip.setInPlay(False)
                End If
                If (Player1.getHelicopter.getInPlay) Then
                    objGraphic.FillRectangle(RedBrush, 10, 303, 25, 25)
                    Player1.getHelicopter.setDestroy(True)
                    Player1.getHelicopter.setInPlay(False)
                End If
                Player1.setNewRound(True)
                Call PlaySoundWicked()
            End If
            Player2.setNuking(False)
            objGraphic.FillRectangle(BlueBrush, 755, 342, 25, 25)
        Else
            Player2.resetI()
        End If

        blnDraw = False
        If (ifdrew = True) Then

            If (player1turn = True And newgame) Then
                Player1.setTarget(e.X, e.Y)

                'if point is 0,0 in the array, then change to the last point so an extra line isn't drawn
                Player1.ClearLineStrikeOfNull()

                If (Not Player1.StrikeOffPage) Then
                    'draw the line
                    objGraphic.DrawCurve(RedPen, Player1.getLineStrike)
                    'add target of 5 pixels at end of line
                    objGraphic.FillEllipse(RedBrush, Player1.getTargetX - 2, Player1.getTargetY - 2, 5, 5)

                    If (hitAnIsland()) Then
                        If (Player1.getBoat.getInPlay) Then
                            objGraphic.FillRectangle(RedBrush, 10, 225, 25, 25)
                            Player1.getBoat.setDestroy(True)
                            Player1.getBoat.setInPlay(False)
                            Player1.setNewRound(True)
                            Call PlaySoundHumil()
                        End If

                        If (Player1.getShip.getInPlay) Then
                            objGraphic.FillRectangle(RedBrush, 10, 277, 25, 25)
                            Player1.getShip.setDestroy(True)
                            Player1.getShip.setInPlay(False)
                            Player1.setNewRound(True)
                            Call PlaySoundHumil()
                        End If

                    End If
                Else
                    Call PlaySoundHumil()
                End If
            End If

            'reset stuff
            newgame = False

            If player1turn = True And Not newgame Then
                Player1.resetI()

                Player1.setTarget(e.X, e.Y)

                'if point is 0,0, then change to the last point
                Player1.ClearLineStrikeOfNull()

                If (Not Player1.StrikeOffPage) Then

                    'draw the line
                    objGraphic.DrawCurve(RedPen, Player1.getLineStrike)

                    'add target of 5 pixels at end of line
                    objGraphic.FillEllipse(RedBrush, Player1.getTargetX - 2, Player1.getTargetY - 2, 5, 5)
                    If (hitAnIsland()) Then
                        If (Player1.getBoat.getInPlay) Then
                            objGraphic.FillRectangle(RedBrush, 10, 225, 25, 25)
                            Player1.getBoat.setDestroy(True)
                            Player1.getBoat.setInPlay(False)
                            Player1.setNewRound(True)
                            Call PlaySoundHumil()
                        End If

                        If (Player1.getShip.getInPlay) Then
                            objGraphic.FillRectangle(RedBrush, 10, 277, 25, 25)
                            Player1.getShip.setDestroy(True)
                            Player1.getShip.setInPlay(False)
                            Player1.setNewRound(True)
                            Call PlaySoundHumil()
                        End If

                    End If

                    player1turn = False

                    'test if hit other player's target
                    If (Player1.HitOrMiss(Player2.getTarget)) Then
                        If (Player2.getBoat.getInPlay) Then
                            objGraphic.FillRectangle(BlueBrush, 755, 225, 25, 25)
                            Player2.getBoat.setDestroy(True)
                            Player2.getBoat.setInPlay(False)
                        End If
                        If (Player2.getAirplane.getInPlay) Then
                            objGraphic.FillRectangle(BlueBrush, 755, 251, 25, 25)
                            Player2.getAirplane.setDestroy(True)
                            Player2.getAirplane.setInPlay(False)
                        End If
                        If (Player2.getShip.getInPlay) Then
                            objGraphic.FillRectangle(BlueBrush, 755, 277, 25, 25)
                            Player2.getShip.setDestroy(True)
                            Player2.getShip.setInPlay(False)
                        End If
                        If (Player2.getHelicopter.getInPlay) Then
                            objGraphic.FillRectangle(BlueBrush, 755, 303, 25, 25)
                            Player2.getHelicopter.setDestroy(True)
                            Player2.getHelicopter.setInPlay(False)
                        End If
                        Player2.setNewRound(True)
                        Call PlaySoundHeadShot()
                    End If

                Else 'destroy whatever player 1 had in play

                    If (Player1.getBoat.getInPlay) Then
                        objGraphic.FillRectangle(RedBrush, 10, 225, 25, 25)
                        Player1.getBoat.setDestroy(True)
                        Player1.getBoat.setInPlay(False)
                    End If
                    If (Player1.getAirplane.getInPlay) Then
                        objGraphic.FillRectangle(RedBrush, 10, 251, 25, 25)
                        Player1.getAirplane.setDestroy(True)
                        Player1.getAirplane.setInPlay(False)
                    End If
                    If (Player1.getShip.getInPlay) Then
                        objGraphic.FillRectangle(RedBrush, 10, 277, 25, 25)
                        Player1.getShip.setDestroy(True)
                        Player1.getShip.setInPlay(False)
                    End If
                    If (Player1.getHelicopter.getInPlay) Then
                        objGraphic.FillRectangle(RedBrush, 10, 303, 25, 25)
                        Player1.getHelicopter.setDestroy(True)
                        Player1.getHelicopter.setInPlay(False)
                    End If
                    Player1.setNewRound(True)
                    Call PlaySoundHumil()
                End If

                If (ifGameOver()) Then
                    displayWin()
                End If

                'reset stuff
                Player1.clearStrike()

            Else
                Player2.resetI()

                Player2.setTarget(e.X, e.Y)

                'if point is 0,0, then change to the last point
                Player2.ClearLineStrikeOfNull()

                'player 2 tests
                If (Not Player2.StrikeOffPage) Then

                    'draw the line
                    objGraphic.DrawCurve(BluePen, Player2.getLineStrike)

                    'add target of 5 pixels at end of line
                    objGraphic.FillEllipse(BlueBrush, Player2.getTargetX - 2, Player2.getTargetY - 2, 5, 5)

                    If (hitAnIsland()) Then
                        If (Player2.getBoat.getInPlay) Then
                            objGraphic.FillRectangle(BlueBrush, 755, 225, 25, 25)
                            Player2.getBoat.setDestroy(True)
                            Player2.getBoat.setInPlay(False)
                            Player2.setNewRound(True)
                            Call PlaySoundHumil()
                        End If

                        If (Player2.getShip.getInPlay) Then
                            objGraphic.FillRectangle(BlueBrush, 755, 277, 25, 25)
                            Player2.getShip.setDestroy(True)
                            Player2.getShip.setInPlay(False)
                            Player2.setNewRound(True)
                            Call PlaySoundHumil()
                        End If

                    End If

                    player1turn = True

                    'test if hit other player's target
                    If (Player2.HitOrMiss(Player1.getTarget)) Then
                        If (Player1.getBoat.getInPlay) Then
                            objGraphic.FillRectangle(RedBrush, 10, 225, 25, 25)
                            Player1.getBoat.setDestroy(True)
                            Player1.getBoat.setInPlay(False)
                        End If
                        If (Player1.getAirplane.getInPlay) Then
                            objGraphic.FillRectangle(RedBrush, 10, 251, 25, 25)
                            Player1.getAirplane.setDestroy(True)
                            Player1.getAirplane.setInPlay(False)
                        End If
                        If (Player1.getShip.getInPlay) Then
                            objGraphic.FillRectangle(RedBrush, 10, 277, 25, 25)
                            Player1.getShip.setDestroy(True)
                            Player1.getShip.setInPlay(False)
                        End If
                        If (Player1.getHelicopter.getInPlay) Then
                            objGraphic.FillRectangle(RedBrush, 10, 303, 25, 25)
                            Player1.getHelicopter.setDestroy(True)
                            Player1.getHelicopter.setInPlay(False)
                        End If
                        Player1.setNewRound(True)
                        Call PlaySoundHeadShot()
                    End If
                Else 'destroy the machine if it went off the page
                    If (Player2.getBoat.getInPlay) Then
                        objGraphic.FillRectangle(BlueBrush, 755, 225, 25, 25)
                        Player2.getBoat.setDestroy(True)
                        Player2.getBoat.setInPlay(False)
                    End If
                    If (Player2.getAirplane.getInPlay) Then
                        objGraphic.FillRectangle(BlueBrush, 755, 251, 25, 25)
                        Player2.getAirplane.setDestroy(True)
                        Player2.getAirplane.setInPlay(False)
                    End If
                    If (Player2.getShip.getInPlay) Then
                        objGraphic.FillRectangle(BlueBrush, 755, 277, 25, 25)
                        Player2.getShip.setDestroy(True)
                        Player2.getShip.setInPlay(False)
                    End If
                    If (Player2.getHelicopter.getInPlay) Then
                        objGraphic.FillRectangle(BlueBrush, 755, 303, 25, 25)
                        Player2.getHelicopter.setDestroy(True)
                        Player2.getHelicopter.setInPlay(False)
                    End If
                    Player2.setNewRound(True)
                    Call PlaySoundHumil()
                End If

                If (ifGameOver()) Then
                    displayWin()
                End If

                'reset stuff
                Player2.clearStrike()

            End If
        Else
            If (player1turn) Then
                Player1.clearStrike()
            Else
                Player2.clearStrike()
            End If

        End If

        'display player's turn
        If (player1turn) Then
            Form1.ActiveForm.Text = "Bash  (Player 1s turn)"
        End If
        If Not (player1turn) Then
            Form1.ActiveForm.Text = "Bash  (Player 2s turn)"
        End If

    End Sub

    Private Sub tmrDraw_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDraw.Tick
        Dim Surface As Graphics = Me.CreateGraphics
        Dim tempRect As Rectangle
        Dim i As Integer
        Dim j As Integer
        Dim bigfont As New Font("Verdana", 16, FontStyle.Regular)

        tempRect = Player1.getBaseRect()

        'draw both bases
        For i = 0 To 1
            For j = 0 To 3
                If (i = 0) Then
                    Surface.DrawRectangle(RedPen, tempRect)
                    tempRect.Y += 26
                End If
                If (i = 1) Then
                    Surface.DrawRectangle(BluePen, tempRect)
                    tempRect.Y += 26
                End If
            Next
            tempRect.Y -= 26 * 4
            tempRect.X += 745
        Next

        tempRect.Y = 316 + 26
        tempRect.X = 10
        Surface.DrawRectangle(RedPen, tempRect)

        tempRect.X = 755
        Surface.DrawRectangle(BluePen, tempRect)

        'draw letters
        Surface.DrawString("B", bigfont, RedBrush, 10, 225)
        Surface.DrawString("A", bigfont, RedBrush, 10, 225 + 26)
        Surface.DrawString("S", bigfont, RedBrush, 10, 225 + 26 * 2)
        Surface.DrawString("H", bigfont, RedBrush, 10, 225 + 26 * 3)
        Surface.DrawString("N", bigfont, RedBrush, 10, 255 + 87)

        Surface.DrawString("B", bigfont, BlueBrush, 755, 225)
        Surface.DrawString("A", bigfont, BlueBrush, 755, 225 + 26)
        Surface.DrawString("S", bigfont, BlueBrush, 755, 225 + 26 * 2)
        Surface.DrawString("H", bigfont, BlueBrush, 755, 225 + 26 * 3)
        Surface.DrawString("N", bigfont, BlueBrush, 755, 255 + 87)

        'draw island
        drawIsland()

    End Sub

    Private Sub tmrTurn_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTurn.Tick

        blnDraw = False
        tmrTurn.Enabled = False

    End Sub

    Function setMachineInPlay(ByVal x As Integer, ByVal y As Integer) As Boolean

        If (((x >= 10 And x <= 35) And (y >= 225 And y <= 250)) And Not (Player1.getBoat.getDestroy)) Then
            Player1.getBoat.setInPlay(True)
            Return True
        End If
        If (((x >= 10 And x <= 35) And (y >= 251 And y <= 276)) And Not (Player1.getAirplane.getDestroy)) Then
            Player1.getAirplane.setInPlay(True)
            Return True
        End If
        If (((x >= 10 And x <= 35) And (y >= 277 And y <= 302)) And Not (Player1.getShip.getDestroy)) Then
            Player1.getShip.setInPlay(True)
            Return True
        End If
        If (((x >= 10 And x <= 35) And (y >= 303 And y <= 328)) And Not (Player1.getHelicopter.getDestroy)) Then
            Player1.getHelicopter.setInPlay(True)
            Return True
        End If

        If (((x >= 755 And x <= 780) And (y >= 225 And y <= 250)) And Not (Player2.getBoat.getDestroy)) Then
            Player2.getBoat.setInPlay(True)
            Return True
        End If
        If (((x >= 755 And x <= 780) And (y >= 251 And y <= 276)) And Not (Player2.getAirplane.getDestroy)) Then
            Player2.getAirplane.setInPlay(True)
            Return True
        End If
        If (((x >= 755 And x <= 780) And (y >= 277 And y <= 302)) And Not (Player2.getShip.getDestroy)) Then
            Player2.getShip.setInPlay(True)
            Return True
        End If
        If (((x >= 755 And x <= 780) And (y >= 303 And y <= 328)) And Not (Player2.getHelicopter.getDestroy)) Then
            Player2.getHelicopter.setInPlay(True)
            Return True
        End If

        Return False

    End Function

    Function ifGameOver() As Boolean

        If (Player1.getBoat.getDestroy And Player1.getAirplane.getDestroy And _
            Player1.getShip.getDestroy And Player1.getHelicopter.getDestroy) Then
            Return True
        End If
        If (Player2.getBoat.getDestroy And Player2.getAirplane.getDestroy And _
            Player2.getShip.getDestroy And Player2.getHelicopter.getDestroy) Then
            Return True
        End If

        Return False

    End Function

    Function hitAnIsland() As Boolean

        Dim i As Integer
        Dim j As Integer
        Dim k As Integer

        If (player1turn) Then

            For i = 0 To Player1.getLineStrike.Length - 1

                If (Player1.getLineStrike(i).X >= Island.X And Player1.getLineStrike(i).X <= Island.X + Island.Width) Then

                    If (Player1.getLineStrike(i).Y >= Island.Y And Player1.getLineStrike(i).Y <= Island.Y + Island.Height) Then
                        Return True
                    End If

                End If

            Next

        End If

        If (Not player1turn) Then

            For i = 0 To Player1.getLineStrike.Length - 1

                If (Player2.getLineStrike(i).X >= Island.X And Player2.getLineStrike(i).X <= Island.X + Island.Width) Then

                    If (Player2.getLineStrike(i).Y >= Island.Y And Player2.getLineStrike(i).Y <= Island.Y + Island.Height) Then
                        Return True
                    End If

                End If

            Next

        End If

        Return False

    End Function

    Function drawIsland() As Integer

        If (Not ifdrewisland) Then
            Dim Surface As Graphics = Me.CreateGraphics

            Randomize()

            Dim x As Integer
            Dim y As Integer
            Dim width As Integer
            Dim height As Integer

            x = Int(500 * Rnd()) + 50
            y = Int(350 * Rnd()) + 50
            width = Int(50 * Rnd()) + 150
            height = Int(50 * Rnd()) + 150


            Island = New Rectangle(x, y, width, height)

            Surface.FillRectangle(GreenBrush, Island)

            ifdrewisland = True

        End If

    End Function

    Function MakeOtherPlayerTargetBig(ByVal po As Point)

        Dim Surface As Graphics = Me.CreateGraphics

        Surface.FillRectangle(OrangeBrush, po.X - 6, po.Y - 6, 13, 13)

    End Function

    Function displayWin() As Integer
        If (player1turn) Then
            MsgBox("Player 2 wins!", MsgBoxStyle.Exclamation, "Winner")
        End If
        If Not (player1turn) Then
            MsgBox("Player 1 wins!", MsgBoxStyle.Exclamation, "Winner")
        End If
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call PlaySoundPrepare()
    End Sub

    'Function to play a sound
    Declare Function sndPlaySound32 Lib "winmm.dll" Alias "sndPlaySoundA" _
        (ByVal lpszSoundName As String, ByVal uFlags As Long) As Long

    'Headshot
    Private Sub PlaySoundHeadShot()
        If True Then
            Call sndPlaySound32("Sound\headshot.wav", 0)
        End If
    End Sub

    'Prepare to fight
    Private Sub PlaySoundPrepare()
        If True Then
            Call sndPlaySound32("Sound\prepare.wav", 0)
        End If
    End Sub

    'Humiliation
    Private Sub PlaySoundHumil()
        If True Then
            Call sndPlaySound32("Sound\humiliation.wav", 0)
        End If
    End Sub

    'Wicked sick
    Private Sub PlaySoundWicked()
        If True Then
            Call sndPlaySound32("Sound\wickedsick.wav", 0)
        End If
    End Sub

    Private Sub FourthSecond_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FourthSecond.Click
        FourthSecond.Checked = True
        HalfSecond.Checked = False
        OneSecond.Checked = False
        tmrTurn.Interval = 250
    End Sub

    Private Sub HalfSecond_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HalfSecond.Click
        FourthSecond.Checked = False
        HalfSecond.Checked = True
        OneSecond.Checked = False
        tmrTurn.Interval = 500
    End Sub

    Private Sub OneSecond_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OneSecond.Click
        FourthSecond.Checked = False
        HalfSecond.Checked = False
        OneSecond.Checked = True
        tmrTurn.Interval = 100
    End Sub

    Private Sub Credits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Credits.Click
        MsgBox("willjasen - Main Programmer" & ControlChars.CrLf & "dustin - Programmer And Tester", MsgBoxStyle.Exclamation, "Credits")
    End Sub
End Class

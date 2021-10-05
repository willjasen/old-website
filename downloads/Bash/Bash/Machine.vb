Public Class Machine
    Inherits System.Windows.Forms.Form

    'Machine.vb

    Private inPlay As Boolean
    Private wasDestroyed As Boolean

    'constructor
    Sub New(ByVal canFly As Boolean)
        inPlay = False
        wasDestroyed = False
    End Sub

    'mutator methods
    Function setDestroy(ByVal destroy As Boolean) As Integer
        wasDestroyed = destroy
    End Function

    Function setInPlay(ByVal p As Boolean) As Integer
        inPlay = p
    End Function

    'accessor methods
    Function getDestroy() As Boolean
        Return wasDestroyed
    End Function

    Function getInPlay() As Boolean
        Return inPlay
    End Function

End Class

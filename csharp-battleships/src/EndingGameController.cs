
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
using SwinGameSDK;

/// <summary>
/// The EndingGameController is responsible for managing the interactions at the end
/// of a game.
/// </summary>

static class EndingGameController
{

	/// <summary>
	/// Draw the end of the game screen, shows the win/lose state
	/// </summary>
	public static void DrawEndOfGame()
	{
		UtilityFunctions.DrawField(GameController.ComputerPlayer.PlayerGrid, GameController.ComputerPlayer, true);
		UtilityFunctions.DrawSmallField(GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer);

		if (GameController.HumanPlayer.IsDestroyed) {
			SwinGame.DrawTextLines("YOU LOSE!", Color.Red, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, 50, 150, SwinGame.ScreenWidth() - 100, SwinGame.ScreenHeight() - 350);
		} else {
			SwinGame.DrawTextLines("-- WINNER --", Color.Green, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, 50, 150, SwinGame.ScreenWidth() - 100, SwinGame.ScreenHeight() - 350);
		}
	}

	/// <summary>
	/// Handle the input during the end of the game. Any interaction
	/// will result in it reading in the highsSwinGame.
	/// </summary>
	public static void HandleEndOfGameInput()
	{
        HighScoreController.ReadHighScore(GameController.HumanPlayer.Score);
        
        if (SwinGame.KeyTyped(KeyCode.vk_RETURN) || SwinGame.KeyTyped(KeyCode.vk_ESCAPE)) {
            GameController.EndCurrentState();
            GameController.AddNewState(GameState.ViewingEndHighScores);
        }
    }

}

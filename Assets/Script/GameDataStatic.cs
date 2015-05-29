using System.Collections;

public static class GameDataStatic {
	static int playingSum = 1;
	
	public static int GetPlayingSum() {
		return playingSum;
	}
	
	public static void AddPlaying() {
		playingSum += 1;
	}
}

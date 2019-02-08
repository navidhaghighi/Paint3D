using UnityEngine;

public static class Globals {
	public static Texture2D userModelTexture;
	//is the model we want to paint a model user uploaded?
	public static bool isUserModel;
	public static string[] playerModelNames;
	public static Texture2D currentBrushTexture;
	public static GameObject currentModel;
	public static Vector2 currentBrushSize;
	public const string modelsPath = "PaintableModels";
	public static string modelName ;
	public const string imageSaveMsg = "اسکرین شات از مدل شما دخیره شد";
	public const string imageSaveFailMsg = "ذخیره اسکرین شات موفق نبود.";
	}

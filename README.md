# 📌 Unity Helpers: Main Thread Dispatcher & Timed Function Helper

This repository contains two simple but powerful helper MonoBehaviours for Unity developers:

- `UnityMainThreadDispatcher.cs`  
- `TimedFunctionHelper.cs`

These utility scripts simplify common challenges such as:

- Running code on the main Unity thread from background threads (e.g., async tasks)
- Delaying execution of actions without needing to write full coroutines everywhere

## 🧵 UnityMainThreadDispatcher

### ✅ Purpose:
Allows you to **safely execute actions on Unity’s main thread**, even if they are triggered from background threads (like async/await, REST APIs, or custom threads).

### 🔧 Why You Need It:
Unity API calls (like `Instantiate`, `SceneManager.LoadScene`, `UI updates`, etc.) must be made on the main thread. If you call them from other threads, your app will crash or behave unexpectedly. `UnityMainThreadDispatcher` solves this by queueing the actions and executing them in `Update()`.

### 🧪 Example Usage:

```csharp
await Task.Run(() =>
{
    // Some background work...
    UnityMainThreadDispatcher.Instance.Enqueue(() =>
    {
        // Now safe to call Unity API here
        Debug.Log("Running on the main thread!");
    });
});
```

## ⏱ TimedFunctionHelper

### ✅ Purpose:
Allows you to **easily schedule function calls after a delay** — without having to write your own coroutine.

### 🔧 Why You Need It:
Sometimes you just want to delay an action without setting up an entire coroutine. `TimedFunctionHelper` gives you a clean `Invoke()` function that does just that.

### 🧪 Example Usage:

```csharp
TimedFunctionHelper.Instance.Invoke(() =>
{
    Debug.Log("This runs after 2 seconds!");
}, 2f);
```

## 🧩 Integration

1. Add both scripts to your `Assets/Scripts/Helpers` folder (or anywhere you prefer).
2. Drag **both scripts onto empty GameObjects in your first scene**.
3. Mark those objects as `DontDestroyOnLoad` (or let the script do it automatically).
4. Enjoy cleaner and more maintainable asynchronous or delayed logic!

## ⚙️ Technologies Used

- Unity C#
- MonoBehaviour
- Coroutines
- Async/Await
- Thread-safe queues

## 💡 Ideal Use Cases

- Networking callbacks that return off the main thread
- Delayed animation triggering
- Safe prefab instantiation from async methods
- UI updates from background work

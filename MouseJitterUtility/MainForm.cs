// Planned Features:
//Customizable Jitter Patterns: Instead of purely random jitter, allow users to define custom patterns or presets for the mouse movements. For example, users could specify a specific sequence of mouse movements or create a custom path for the mouse to follow.
//Timing and Intensity Settings: Provide options for users to adjust the timing and intensity of the mouse jitter. They could specify the frequency of movements, the duration of pauses between movements, or the overall intensity of the jitter effect.
//Smooth Transition Effects: Implement smooth transitions between mouse positions to make the jittering appear more natural. You can achieve this by using easing functions or interpolations to generate smoother movement trajectories.
//Randomized Mouse Clicks: In addition to mouse movement, you can incorporate random mouse clicks to further simulate user activity. This could involve clicking at random positions or within a predefined region.
//Configurable Hotkeys: Allow users to customize the hotkeys used to start and stop the jittering. This would provide flexibility for users who may prefer different key combinations.
//Tray Icon and Notifications: Add a system tray icon and provide notifications or tooltips to indicate the status of the jittering program. This would make it easier for users to control and monitor the application from the system tray.
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MouseJitterUtility
{
    public partial class MainForm : Form
    {
        #region Fields

        private bool isJittering = false;
        private Hotkey hotkey;
        private bool enableSmoothTransitions = false;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();

            // Initialize the hotkey with Shift + J and the ToggleJitter method as the callback
            hotkey = new Hotkey(Keys.J, KeyModifier.Shift, ToggleJitter);

            // Register the hotkey with the current form
            hotkey.Register(this);

            // Retrieve and set the initial values for the text boxes
            txtMinDistance.Text = Properties.Settings.Default.minDistance.ToString();
            txtMaxDistance.Text = Properties.Settings.Default.maxDistance.ToString();
        }

        #endregion

        #region Event Handlers
        private void chkSmoothTransitions_CheckedChanged(object sender, EventArgs e)
        {
            enableSmoothTransitions = chkSmoothTransitions.Checked;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            ToggleJitter();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the current values of the text boxes to application settings
            Properties.Settings.Default.minDistance = int.Parse(txtMinDistance.Text);
            Properties.Settings.Default.maxDistance = int.Parse(txtMaxDistance.Text);
            Properties.Settings.Default.Save();

            // Unregister the hotkey
            hotkey.Unregister();
        }

        #endregion

        #region Private Methods

        private void ToggleJitter()
        {
            if (isJittering)
            {
                StopJitter();
            }
            else
            {
                StartJitter();
            }
        }

        private void StartJitter()
        {
            isJittering = true;
            btnStartStop.Text = "Stop";

            // Start moving the mouse
            MoveMouse();
        }

        private void StopJitter()
        {
            isJittering = false;
            btnStartStop.Text = "Start";
        }

        private void MoveMouse()
        {
            Random random = new Random();

            // Retrieve the stored minimum and maximum jitter distances from application settings
            int minJitterDistance = int.Parse(txtMinDistance.Text);
            int maxJitterDistance = int.Parse(txtMaxDistance.Text);

            // Update the text boxes with the new values
            txtMinDistance.Text = minJitterDistance.ToString();
            txtMaxDistance.Text = maxJitterDistance.ToString();


            // Set the interval between mouse movements in milliseconds
            int movementInterval = 20;

            // Get the current mouse position
            Point currentPosition = Cursor.Position;

            // Generate a random jitter distance within the specified range
            int jitterDistance = random.Next(minJitterDistance, maxJitterDistance + 1);

            // Calculate the target position based on the jitter distance
            int targetX = currentPosition.X + random.Next(-jitterDistance, jitterDistance);
            int targetY = currentPosition.Y + random.Next(-jitterDistance, jitterDistance);

            // Ensure the target coordinates are within the screen bounds
            targetX = Math.Max(0, Math.Min(Screen.PrimaryScreen.Bounds.Width - 1, targetX));
            targetY = Math.Max(0, Math.Min(Screen.PrimaryScreen.Bounds.Height - 1, targetY));

            // Calculate the number of steps for smooth movement
            int steps = enableSmoothTransitions ? 15 : 1;

            for (int i = 0; i <= steps; i++)
            {
                // Calculate the interpolation factor based on the current step
                double t = enableSmoothTransitions ? Interpolation.EaseInOutCubic((double)i / steps) : 1.0;

                // Calculate the intermediate position using interpolation
                int intermediateX = (int)(currentPosition.X + (targetX - currentPosition.X) * t);
                int intermediateY = (int)(currentPosition.Y + (targetY - currentPosition.Y) * t);

                // Move the mouse to the intermediate position
                Cursor.Position = new Point(intermediateX, intermediateY);

                // Sleep for a short interval to create smooth movement
                System.Threading.Thread.Sleep(movementInterval);
            }

            if (isJittering)
            {
                // Schedule the next mouse movement
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = movementInterval * 10;  // Increase the interval for smoother movement
                timer.Tick += (sender, e) =>
                {
                    MoveMouse();
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }

        #endregion

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312 && m.WParam.ToInt32() == hotkey.id)
            {
                hotkey.callback.Invoke();
            }
        }
    

    #region Hotkey Class

    public class Hotkey : IDisposable
        {
            #region Fields

            public int id;
            private readonly IntPtr handle;
            public readonly KeyModifier modifier;
            public readonly Keys key;
            public readonly Action callback;

            #endregion

            #region Constructor

            public Hotkey(Keys key, KeyModifier modifier, Action callback)
            {
                this.key = key;
                this.modifier = modifier;
                this.callback = callback;
                handle = IntPtr.Zero;
            }

            #endregion

            #region Public Methods

            public void Register(Form form)
            {
                // Generate a unique ID for the hotkey based on the form's hash code
                id = form.GetHashCode();

                // Register the hotkey with the form's handle
                if (!RegisterHotKey(form.Handle, id, (int)modifier, (int)key))
                    throw new InvalidOperationException("Couldn't register the hotkey.");
            }

            public void Unregister()
            {
                // Unregister the hotkey
                UnregisterHotKey(handle, id);
            }

            public void Dispose()
            {
                // Unregister the hotkey when disposing the object
                Unregister();
            }

            #endregion

            #region Native Methods

            [DllImport("user32.dll")]
            private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

            [DllImport("user32.dll")]
            private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

            #endregion
        }

        #endregion

        #region Enum

        [Flags]
        public enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            Win = 8
        }

        #endregion
    }
    #region Interpolation Class

    public static class Interpolation
    {
        // Easing functions for smooth transitions
        public static double EaseInOutCubic(double t)
        {
            return t < 0.5 ? 4 * t * t * t : 1 - Math.Pow(-2 * t + 2, 3) / 2;
        }
    }

    #endregion
}

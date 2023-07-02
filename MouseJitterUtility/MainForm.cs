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
        private bool isJittering = false;
        private Hotkey hotkey;

        public MainForm()
        {
            InitializeComponent();
            hotkey = new Hotkey(Keys.J, KeyModifier.Shift, ToggleJitter);
            hotkey.Register(this);

            // Retrieve and set the initial values for the text boxes
            txtMinDistance.Text = Properties.Settings.Default.minDistance.ToString();
            txtMaxDistance.Text = Properties.Settings.Default.maxDistance.ToString();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            ToggleJitter();
        }

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

            // Calculate the step distance for smooth movement
            double stepX = (targetX - currentPosition.X) / 15.0;
            double stepY = (targetY - currentPosition.Y) / 15.0;

            for (int i = 0; i < 10; i++)
            {
                // Calculate the intermediate position
                int intermediateX = (int)(currentPosition.X + stepX * i);
                int intermediateY = (int)(currentPosition.Y + stepY * i);

                // Move the mouse to the intermediate position
                Cursor.Position = new Point(intermediateX, intermediateY);

                // Sleep for a short interval to create smooth movement
                System.Threading.Thread.Sleep(movementInterval);
            }

            // Move the mouse to the final target position
            Cursor.Position = new Point(targetX, targetY);

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


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the current values of the text boxes to application settings
            Properties.Settings.Default.minDistance = int.Parse(txtMinDistance.Text);
            Properties.Settings.Default.maxDistance = int.Parse(txtMaxDistance.Text);
            Properties.Settings.Default.Save();

            hotkey.Unregister();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312 && m.WParam.ToInt32() == hotkey.id)
            {
                hotkey.callback.Invoke();
            }
        }
    }

    public class Hotkey : IDisposable
    {
        public int id;
        private readonly IntPtr handle;
        public readonly KeyModifier modifier;
        public readonly Keys key;
        public readonly Action callback;


        public Hotkey(Keys key, KeyModifier modifier, Action callback)
        {
            this.key = key;
            this.modifier = modifier;
            this.callback = callback;
            handle = IntPtr.Zero;
        }

        public void Register(Form form)
        {
            id = form.GetHashCode();
            if (!RegisterHotKey(form.Handle, id, (int)modifier, (int)key))
                throw new InvalidOperationException("Couldn't register the hotkey.");
        }

        public void Unregister()
        {
            UnregisterHotKey(handle, id);
        }

        public void Dispose()
        {
            Unregister();
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }

    [Flags]
    public enum KeyModifier
    {
        None = 0,
        Alt = 1,
        Ctrl = 2,
        Shift = 4,
        Win = 8
    }
}

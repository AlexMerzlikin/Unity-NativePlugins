package com.alexm.unitytoast;

import android.app.Application;
import android.content.Context;
import android.os.Handler;
import android.os.Looper;
import android.widget.Toast;

public class ToastPlugin extends Application
{
    private Context context;

    public ToastPlugin(Context context)
    {
        this.context = context;
    }

    public void ShowToast(final String message)
    {
        new Handler(Looper.getMainLooper())
                .post(new Runnable()
                {
                    @Override
                    public void run()
                    {
                        Toast.makeText(context, message, Toast.LENGTH_SHORT)
                                .show();
                    }
                });
    }

    public void ShowToast(final String message, final int duration)
    {
        new Handler(Looper.getMainLooper())
                .post(new Runnable()
                {
                    @Override
                    public void run()
                    {
                        Toast.makeText(context, message, duration)
                                .show();
                    }
                });
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using System;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    
    }
#if UNITY_ANDROID
    private void Start()
    {
        StartCoroutine(PermisionRecuest());
    }
    private const string channelId = "notificationChanel";

    public void CrearNotificacion(DateTime fecha)
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Id = channelId,
            Name = "NotifChanel",
            Importance = Importance.Default,
            Description = "NotifChanel",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        AndroidNotification androidNotification = new AndroidNotification()
        {
            Title = "Revisa Las Recompensas",
            Text = "Recompensa de anuncios disponible",
            FireTime = fecha,
            SmallIcon = "default",
            LargeIcon = "default",
        };
        AndroidNotificationCenter.SendNotification(androidNotification, channelId);
    }
    IEnumerator PermisionRecuest()
    {
        var recuest = new PermissionRequest();
        while(recuest.Status == PermissionStatus.RequestPending)
        {
            yield return null;
        }
    }

#endif
}

using System;
using System.Collections.Generic;

namespace agorartc
{
    using uid_t = UInt32;
    using view_t = IntPtr;
    using IRtcChannelBridge_ptr = IntPtr;

    internal class NativeRtcChannelEventHandler
    {
        private static readonly Dictionary<string, AgoraRtcChannel> Channels =
            new Dictionary<string, AgoraRtcChannel>();

        internal static void AddChannel(string channelId, AgoraRtcChannel _Channel)
        {
            Channels.Add(channelId, _Channel);
        }

        internal static void RemoveChannel(string channelId)
        {
            Channels.Remove(channelId);
        }

        internal static void OnChannelWarning(string channelId, int warn, string msg)
        {
            Channels[channelId]?.channelEventHandler?.OnChannelWarning(channelId, warn, msg);
        }

        internal static void OnChannelError(string channelId, int err, string msg)
        {
            Channels[channelId]?.channelEventHandler?.OnChannelError(channelId, err, msg);
        }

        internal static void OnChannelJoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
            Channels[channelId]?.channelEventHandler?.OnChannelJoinChannelSuccess(channelId, uid, elapsed);
        }

        internal static void OnChannelReJoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
            Channels[channelId].channelEventHandler.OnChannelReJoinChannelSuccess(channelId, uid, elapsed);
        }

        internal static void OnChannelLeaveChannel(string channelId, uint duration, uint txBytes, uint rxBytes,
            uint txAudioBytes, uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate,
            ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate,
            ushort txVideoKBitRate, ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate,
            uint userCount,
            double cpuAppUsage, double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio,
            double memoryTotalUsageRatio, int memoryAppUsageInKbytes)
        {
            Channels[channelId].channelEventHandler.OnChannelLeaveChannel(channelId, duration, txBytes, rxBytes,
                txAudioBytes, txVideoBytes, rxAudioBytes, rxVideoBytes, txKBitRate, rxKBitRate, rxAudioKBitRate,
                txAudioKBitRate, rxVideoKBitRate, txVideoKBitRate, lastmileDelay, txPacketLossRate, rxPacketLossRate,
                userCount, cpuAppUsage, cpuTotalUsage, gatewayRtt, memoryAppUsageRatio, memoryTotalUsageRatio,
                memoryAppUsageInKbytes);
        }

        internal static void OnChannelClientRoleChanged(string channelId, int oldRole, int newRole)
        {
            Channels[channelId].channelEventHandler.OnChannelClientRoleChanged(channelId, oldRole, newRole);
        }

        internal static void OnChannelUserJoined(string channelId, uint uid, int elapsed)
        {
            Channels[channelId].channelEventHandler.OnChannelUserJoined(channelId, uid, elapsed);
        }

        internal static void OnChannelUserOffLine(string channelId, uint uid, int reason)
        {
            Channels[channelId].channelEventHandler.OnChannelUserOffLine(channelId, uid, reason);
        }

        internal static void OnChannelConnectionLost(string channelId)
        {
            Channels[channelId].channelEventHandler.OnChannelConnectionLost(channelId);
        }

        internal static void OnChannelRequestToken(string channelId)
        {
            Channels[channelId].channelEventHandler.OnChannelRequestToken(channelId);
        }

        internal static void OnChannelTokenPrivilegeWillExpire(string channelId, string token)
        {
            Channels[channelId].channelEventHandler.OnChannelTokenPrivilegeWillExpire(channelId, token);
        }

        internal static void OnChannelRtcStats(string channelId, uint duration, uint txBytes, uint rxBytes,
            uint txAudioBytes, uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate,
            ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate,
            ushort txVideoKBitRate, ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate,
            uint userCount,
            double cpuAppUsage, double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio,
            double memoryTotalUsageRatio, int memoryAppUsageInKbytes)
        {
            Channels[channelId].channelEventHandler.OnChannelRtcStats(channelId, duration, txBytes, rxBytes,
                txAudioBytes, txVideoBytes, rxAudioBytes, rxVideoBytes, txKBitRate, rxKBitRate, rxAudioKBitRate,
                txAudioKBitRate, rxVideoKBitRate, txVideoKBitRate, lastmileDelay, txPacketLossRate, rxPacketLossRate,
                userCount, cpuAppUsage, cpuTotalUsage, gatewayRtt, memoryAppUsageRatio, memoryTotalUsageRatio,
                memoryAppUsageInKbytes);
        }

        internal static void OnChannelNetworkQuality(string channelId, uint uid, int txQuality, int rxQuality)
        {
            Channels[channelId].channelEventHandler.OnChannelNetworkQuality(channelId, uid, txQuality, rxQuality);
        }

        internal static void OnChannelRemoteVideoStats(string channelId, uint uid, int delay, int width,
            int height,
            int receivedBitrate, int decoderOutputFrameRate, int rendererOutputFrameRate, int packetLossRate,
            int rxStreamType, int totalFrozenTime, int frozenRate, int totalActiveTime)
        {
            Channels[channelId].channelEventHandler.OnChannelRemoteVideoStats(channelId, uid, delay, width, height,
                receivedBitrate, decoderOutputFrameRate, rendererOutputFrameRate, packetLossRate, rxStreamType,
                totalFrozenTime, frozenRate, totalActiveTime);
        }

        internal static void OnChannelRemoteAudioStats(string channelId, uint uid, int quality,
            int networkTransportDelay, int jitterBufferDelay, int audioLossRate, int numChannels,
            int receivedSampleRate,
            int receivedBitrate, int totalFrozenTime, int frozenRate, int totalActiveTime)
        {
            Channels[channelId].channelEventHandler.OnChannelRemoteAudioStats(channelId, uid, quality,
                networkTransportDelay, jitterBufferDelay, audioLossRate, numChannels, receivedSampleRate,
                receivedBitrate, totalFrozenTime, frozenRate, totalActiveTime);
        }

        internal static void OnChannelRemoteAudioStateChanged(string channelId, uint uid, int state, int reason,
            int elapsed)
        {
            Channels[channelId].channelEventHandler
                .OnChannelRemoteAudioStateChanged(channelId, uid, state, reason, elapsed);
        }

        internal static void OnChannelActiveSpeaker(string channelId, uint uid)
        {
            Channels[channelId].channelEventHandler.OnChannelActiveSpeaker(channelId, uid);
        }

        internal static void
            OnChannelVideoSizeChanged(string channelId, uint uid, int width, int height, int rotation)
        {
            Channels[channelId].channelEventHandler.OnChannelVideoSizeChanged(channelId, uid, width, height, rotation);
        }

        internal static void OnChannelRemoteVideoStateChanged(string channelId, uint uid, int state, int reason,
            int elapsed)
        {
            Channels[channelId].channelEventHandler
                .OnChannelRemoteVideoStateChanged(channelId, uid, state, reason, elapsed);
        }

        internal static void
            OnChannelStreamMessage(string channelId, uint uid, int streamId, string data, uint length)
        {
            Channels[channelId].channelEventHandler.OnChannelStreamMessage(channelId, uid, streamId, data, length);
        }

        internal static void OnChannelStreamMessageError(string channelId, uint uid, int streamId, int code,
            int missed, int cached)
        {
            Channels[channelId].channelEventHandler
                .OnChannelStreamMessageError(channelId, uid, streamId, code, missed, cached);
        }

        internal static void OnChannelMediaRelayStateChanged2(string channelId, int state, int code)
        {
            Channels[channelId].channelEventHandler.OnChannelMediaRelayStateChanged2(channelId, state, code);
        }

        internal static void OnChannelMediaRelayEvent2(string channelId, int code)
        {
            Channels[channelId].channelEventHandler.OnChannelMediaRelayEvent2(channelId, code);
        }

        internal static void OnChannelRtmpStreamingStateChanged(string channelId, string url, int state,
            int errCode)
        {
            Channels[channelId].channelEventHandler.OnChannelRtmpStreamingStateChanged(channelId, url, state, errCode);
        }

        internal static void OnChannelTranscodingUpdated(string channelId)
        {
            Channels[channelId].channelEventHandler.OnChannelTranscodingUpdated(channelId);
        }

        internal static void OnChannelStreamInjectedStatus(string channelId, string url, uint uid, int status)
        {
            Channels[channelId].channelEventHandler.OnChannelStreamInjectedStatus(channelId, url, uid, status);
        }

        internal static void OnChannelRemoteSubscribeFallbackToAudioOnly(string channelId, uint uid,
            int isFallbackOrRecover)
        {
            Channels[channelId].channelEventHandler
                .OnChannelRemoteSubscribeFallbackToAudioOnly(channelId, uid, isFallbackOrRecover);
        }

        internal static void OnChannelConnectionStateChanged(string channelId, int state, int reason)
        {
            Channels[channelId].channelEventHandler.OnChannelConnectionStateChanged(channelId, state, reason);
        }

        internal static void OnChannelLocalPublishFallbackToAudioOnly(string channelId, int isFallbackOrRecover)
        {
            Channels[channelId].channelEventHandler
                .OnChannelLocalPublishFallbackToAudioOnly(channelId, isFallbackOrRecover);
        }

        internal static void OnChannelTestEnd(string channelId)
        {
            Channels[channelId].channelEventHandler.OnChannelTestEnd(channelId);
        }
    }

    public class AgoraRtcChannel : IDisposable
    {
        private IRtcChannelBridge_ptr _channelHandler;
        private readonly string _channelId;
        private bool disposed = false;
        internal IRtcChannelEventHandlerBase channelEventHandler;

        public AgoraRtcChannel(IRtcChannelBridge_ptr handler, string id)
        {
            _channelHandler = handler;
            _channelId = id;
            NativeRtcChannelEventHandler.AddChannel(id, this);
        }

        /// <summary>
        /// Releases all IRtcChannel resources.
        /// 
        /// Use this method for apps in which users occasionally make voice or video calls. When users do not make calls, you
        /// can free up resources for other operations.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
            }

            channel_remove_C_ChannelEventHandler();
            ReleaseChannel();

            disposed = true;
        }

        /// <summary>
        /// Add event handler to Rtc Channel instance.
        /// </summary>
        /// 
        /// <param name="channelEventHandlerBase">
        /// @param channelEventHandlerBase
        /// An instance of IRtcChannelEventHandlerBase that contains all callback functions in Rtc Channel.
        /// Either can you create an IRtcChannelEventHandlerBase instance or you can rewrite some of the function.
        /// </param>
        public void InitChannelEventHandler(IRtcChannelEventHandlerBase channelEventHandlerBase)
        {
            channelEventHandler = channelEventHandlerBase;
            var myHandler = new ChannelEventHandler
            {
                onWarning = NativeRtcChannelEventHandler.OnChannelWarning,
                onError = NativeRtcChannelEventHandler.OnChannelWarning,
                onJoinChannelSuccess = NativeRtcChannelEventHandler.OnChannelJoinChannelSuccess,
                onRejoinChannelSuccess = NativeRtcChannelEventHandler.OnChannelReJoinChannelSuccess,
                onLeaveChannel = NativeRtcChannelEventHandler.OnChannelLeaveChannel,
                onClientRoleChanged = NativeRtcChannelEventHandler.OnChannelClientRoleChanged,
                onUserJoined = NativeRtcChannelEventHandler.OnChannelUserJoined,
                onUserOffLine = NativeRtcChannelEventHandler.OnChannelUserOffLine,
                onConnectionLost = NativeRtcChannelEventHandler.OnChannelConnectionLost,
                onRequestToken = NativeRtcChannelEventHandler.OnChannelRequestToken,
                onTokenPrivilegeWillExpire = NativeRtcChannelEventHandler.OnChannelTokenPrivilegeWillExpire,
                onRtcStats = NativeRtcChannelEventHandler.OnChannelRtcStats,
                onNetworkQuality = NativeRtcChannelEventHandler.OnChannelNetworkQuality,
                onRemoteVideoStats = NativeRtcChannelEventHandler.OnChannelRemoteVideoStats,
                onRemoteAudioStats = NativeRtcChannelEventHandler.OnChannelRemoteAudioStats,
                onRemoteAudioStateChanged = NativeRtcChannelEventHandler.OnChannelRemoteAudioStateChanged,
                onActiveSpeaker = NativeRtcChannelEventHandler.OnChannelActiveSpeaker,
                onVideoSizeChanged = NativeRtcChannelEventHandler.OnChannelVideoSizeChanged,
                onRemoteVideoStateChanged = NativeRtcChannelEventHandler.OnChannelRemoteVideoStateChanged,
                onStreamMessage = NativeRtcChannelEventHandler.OnChannelStreamMessage,
                onStreamMessageError = NativeRtcChannelEventHandler.OnChannelStreamMessageError,
                onMediaRelayStateChanged = NativeRtcChannelEventHandler.OnChannelMediaRelayStateChanged2,
                onMediaRelayEvent = NativeRtcChannelEventHandler.OnChannelMediaRelayEvent2,
                onRtmpStreamingStateChanged = NativeRtcChannelEventHandler.OnChannelRtmpStreamingStateChanged,
                onTranscodingUpdated = NativeRtcChannelEventHandler.OnChannelTranscodingUpdated,
                onStreamInjectedStatus = NativeRtcChannelEventHandler.OnChannelStreamInjectedStatus,
                onRemoteSubscribeFallbackToAudioOnly =
                    NativeRtcChannelEventHandler.OnChannelRemoteSubscribeFallbackToAudioOnly,
                onConnectionStateChanged = NativeRtcChannelEventHandler.OnChannelConnectionStateChanged,
                onLocalPublishFallbackToAudioOnly =
                    NativeRtcChannelEventHandler.OnChannelLocalPublishFallbackToAudioOnly,
                onTestEnd = NativeRtcChannelEventHandler.OnChannelTestEnd
            };
            channel_add_C_ChannelEventHandler(myHandler);
        }

        private void channel_add_C_ChannelEventHandler(ChannelEventHandler channelEventHandler)
        {
            AgorartcNative.channel_add_C_ChannelEventHandler(_channelHandler, channelEventHandler);
        }

        private void channel_remove_C_ChannelEventHandler()
        {
            AgorartcNative.channel_remove_C_ChannelEventHandler(_channelHandler);
        }

        /// <summary>
        /// Joins the channel with a user ID.
        /// This method differs from the `joinChannel` method in the `IRtcEngine` class in the following aspects:
        /// | IChannel::joinChannel                                                                                                                    | IRtcEngine::joinChannel                                                                                      |
        /// |------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------|
        /// | Does not contain the `channelId` parameter, because `channelId` is specified when creating the `IChannel` object.                              | Contains the `channelId` parameter, which specifies the channel to join.                                       |
        /// | Contains the `options` parameter, which decides whether to subscribe to all streams before joining the channel.                            | Does not contain the `options` parameter. By default, users subscribe to all streams when joining the channel. |
        /// | Users can join multiple channels simultaneously by creating multiple `IChannel` objects and calling the `joinChannel` method of each object. | Users can join only one channel.                                                                             |
        /// | By default, the SDK does not publish any stream after the user joins the channel. You need to call the publish method to do that.        | By default, the SDK publishes streams once the user joins the channel.                                       |
        /// @note
        /// - If you are already in a channel, you cannot rejoin it with the same `uid`.
        /// - We recommend using different UIDs for different channels.
        /// - If you want to join the same channel from different devices, ensure that the UIDs in all devices are different.
        /// - Ensure that the app ID you use to generate the token is the same with the app ID used when creating the `IRtcEngine` object.
        /// </summary>
        ///
        /// <param name="token">
        /// @param token The token for authentication:
        /// - In situations not requiring high security: You can use the temporary token generated at Console. For details, see [Get a temporary token](https://docs.agora.io/en/Agora%20Platform/token?platfor%20*%20m=All%20Platforms#get-a-temporary-token).
        /// - In situations requiring high security: Set it as the token generated at your server. For details, see [Generate a token](https://docs.agora.io/en/Agora%20Platform/token?platfor%20*%20m=All%20Platforms#get-a-token).
        /// </param>
        ///
        /// <param name="info">
        /// @param info (Optional) Additional information about the channel. This parameter can be set as null. Other users in the channel do not receive this information.
        /// </param>
        ///
        /// <param name="uid">
        /// @param uid The user ID. A 32-bit unsigned integer with a value ranging from 1 to (232-1). This parameter must be unique. If `uid` is not assigned (or set as `0`), the SDK assigns a `uid` and reports it in the \ref agora::rtc::IChannelEventHandler::onJoinChannelSuccess "onJoinChannelSuccess" callback. The app must maintain this user ID.
        /// </param>
        ///
        /// <param name="options">
        /// @param options The channel media options: \ref agora::rtc::ChannelMediaOptions::ChannelMediaOptions "ChannelMediaOptions"
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0(ERR_OK): Success.
        /// - &lt; 0: Failure.
        /// - -2(ERR_INALID_ARGUMENT): The parameter is invalid.
        /// - -3(ERR_NOT_READY): The SDK fails to be initialized. You can try re-initializing the SDK.
        /// - -5(ERR_REFUSED): The request is rejected. This may be caused by the following:
        /// - You have created an IChannel object with the same channel name.
        /// - You have joined and published a stream in a channel created by the IChannel object.
        /// </returns>
        public ERROR_CODE channel_joinChannel(string token, string info, uid_t uid, ChannelMediaOptions options)
        {
            return AgorartcNative.channel_joinChannel(_channelHandler, token, info, uid, options);
        }

        /// <summary>
        /// Joins the channel with a user account.
        /// After the user successfully joins the channel, the SDK triggers the following callbacks:
        /// - The local client: \ref agora::rtc::IRtcEngineEventHandler::onLocalUserRegistered "onLocalUserRegistered" and \ref agora::rtc::IChannelEventHandler::onJoinChannelSuccess "onJoinChannelSuccess" .
        /// - The remote client: \ref agora::rtc::IChannelEventHandler::onUserJoined "onUserJoined" and \ref agora::rtc::IRtcEngineEventHandler::onUserInfoUpdated "onUserInfoUpdated" , if the user joining the channel is in the `COMMUNICATION` profile, or is a host in the `LIVE_BROADCASTING` profile.
        /// @note To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account.
        /// If a user joins the channel with the Agora Web SDK, ensure that the uid of the user is set to the same parameter type.
        /// </summary>
        ///
        /// <param name="token">
        /// @param token The token generated at your server:
        /// - For low-security requirements: You can use the temporary token generated at Console. For details, see [Get a temporary toke](https://docs.agora.io/en/Voice/token?platform=All%20Platforms#get-a-temporary-token).
        /// - For high-security requirements: Set it as the token generated at your server. For details, see [Get a token](https://docs.agora.io/en/Voice/token?platform=All%20Platforms#get-a-token).
        /// </param>
        ///
        /// <param name="userAccount">
        /// @param userAccount The user account. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as null. Supported character scopes are:
        /// - All lowercase English letters: a to z.
        /// - All uppercase English letters: A to Z.
        /// - All numeric characters: 0 to 9.
        /// - The space character.
        /// - Punctuation characters and other symbols, including: "!", "#", "$", "%", "&amp;", "(", ")", "+", "-", ":", ";", "&lt;", "=", ".", ">", "?", "@", "[", "]", "^", "_", " {", "}", "|", "~", ",".
        /// </param>
        ///
        /// <param name="options">
        /// @param options The channel media options: \ref agora::rtc::ChannelMediaOptions::ChannelMediaOptions “ChannelMediaOptions”.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// - #ERR_INVALID_ARGUMENT (-2)
        /// - #ERR_NOT_READY (-3)
        /// - #ERR_REFUSED (-5)
        /// </returns>
        public ERROR_CODE channel_joinChannelWithUserAccount(string token, string userAccount,
            ChannelMediaOptions options)
        {
            return AgorartcNative.channel_joinChannelWithUserAccount(_channelHandler, token, userAccount, options);
        }

        /// <summary>
        /// Allows a user to leave a channel, such as hanging up or exiting a call.
        /// After joining a channel, the user must call the *leaveChannel* method to end the call before joining another channel.
        /// This method returns 0 if the user leaves the channel and releases all resources related to the call.
        /// This method call is asynchronous, and the user has not left the channel when the method call returns. Once the user leaves the channel, the SDK triggers the \ref IChannelEventHandler::onLeaveChannel "onLeaveChannel" callback.
        /// A successful \ref agora::rtc::IChannel::leaveChannel "leaveChannel" method call triggers the following callbacks:
        /// - The local client: \ref agora::rtc::IChannelEventHandler::onLeaveChannel "onLeaveChannel"
        /// - The remote client: \ref agora::rtc::IChannelEventHandler::onUserOffline "onUserOffline" , if the user leaving the channel is in the Communication channel, or is a host in the `LIVE_BROADCASTING` profile.
        /// @note
        /// - If you call the \ref IChannel::release "release" method immediately after the *leaveChannel* method, the *leaveChannel* process interrupts, and the \ref IChannelEventHandler::onLeaveChannel "onLeaveChannel" callback is not triggered.
        /// - If you call the *leaveChannel* method during a CDN live streaming, the SDK triggers the \ref IChannel::removePublishStreamUrl "removePublishStreamUrl" method.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0(ERR_OK): Success.
        /// - &lt; 0: Failure.
        /// - -1(ERR_FAILED): A general error occurs (no specified reason).
        /// - -2(ERR_INALID_ARGUMENT): The parameter is invalid.
        /// - -7(ERR_NOT_INITIALIZED): The SDK is not initialized.
        /// </returns>
        public ERROR_CODE channel_leaveChannel()
        {
            return AgorartcNative.channel_leaveChannel(_channelHandler);
        }

        /// <summary>
        /// Publishes the local stream to the channel.
        /// You must keep the following restrictions in mind when calling this method. Otherwise, the SDK returns the #ERR_REFUSED (5):
        /// - This method publishes one stream only to the channel corresponding to the current `IChannel` object.
        /// - In the live interactive streaming channel, only a host can call this method. To switch the client role, call \ref agora::rtc::IChannel::setClientRole "setClientRole" of the current `IChannel` object.
        /// - You can publish a stream to only one channel at a time. For details on joining multiple channels, see the advanced guide *Join Multiple Channels*.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// - #ERR_REFUSED (5): The method call is refused.
        /// </returns>
        public ERROR_CODE channel_publish()
        {
            return AgorartcNative.channel_publish(_channelHandler);
        }

        /// <summary>
        /// Stops publishing a stream to the channel.
        /// If you call this method in a channel where you are not publishing streams, the SDK returns #ERR_REFUSED (5).
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// - #ERR_REFUSED (5): The method call is refused.
        /// </returns>
        public ERROR_CODE channel_unpublish()
        {
            return AgorartcNative.channel_unpublish(_channelHandler);
        }

        /// <summary>
        /// Gets the channel ID of the current `IChannel` object.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - The channel ID of the current `IChannel` object, if the method call succeeds.
        /// - The empty string "", if the method call fails.
        /// </returns>
        public string channel_channelId()
        {
            return AgorartcNative.channel_channelId(_channelHandler);
        }

        /// <summary>
        /// Retrieves the current call ID.
        /// When a user joins a channel on a client, a `callId` is generated to identify the call from the client.
        /// Feedback methods, such as \ref IRtcEngine::rate "rate" and \ref IRtcEngine::complain "complain", must be called after the call ends to submit feedback to the SDK.
        /// The `rate` and `complain` methods require the `callId` parameter retrieved from the `getCallId` method during a call. `callId` is passed as an argument into the `rate` and `complain` methods after the call ends.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public string channel_getCallId()
        {
            return AgorartcNative.channel_getCallId(_channelHandler);
        }

        /// <summary>
        /// Gets a new token when the current token expires after a period of time.
        /// The `token` expires after a period of time once the token schema is enabled when:
        /// - The SDK triggers the \ref IChannelEventHandler::onTokenPrivilegeWillExpire "onTokenPrivilegeWillExpire" callback, or
        /// - The \ref IChannelEventHandler::onConnectionStateChanged "onConnectionStateChanged" reports CONNECTION_CHANGED_TOKEN_EXPIRED(9).
        /// The application should call this method to get the new `token`. Failure to do so will result in the SDK disconnecting from the server.
        /// </summary>
        ///
        /// <param name="token">
        /// @param token Pointer to the new token.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0(ERR_OK): Success.
        /// - &lt; 0: Failure.
        /// - -1(ERR_FAILED): A general error occurs (no specified reason).
        /// - -2(ERR_INALID_ARGUMENT): The parameter is invalid.
        /// - -7(ERR_NOT_INITIALIZED): The SDK is not initialized.
        /// </returns>
        public ERROR_CODE channel_renewToken(string token)
        {
            return AgorartcNative.channel_renewToken(_channelHandler, token);
        }

        /// <summary>
        /// Enables built-in encryption with an encryption password before users join a channel.
        /// @deprecated Deprecated as of v3.1.0. Use the \ref agora::rtc::IChannel::enableEncryption "enableEncryption" instead.
        /// All users in a channel must use the same encryption password. The encryption password is automatically cleared once a user leaves the channel.
        /// If an encryption password is not specified, the encryption functionality will be disabled.
        /// @note
        /// - Do not use this method for CDN live streaming.
        /// - For optimal transmission, ensure that the encrypted data size does not exceed the original data size + 16 bytes. 16 bytes is the maximum padding size for AES encryption.
        /// </summary>
        ///
        /// <param name="secret">
        /// @param secret Pointer to the encryption password.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_setEncryptionSecret(string secret)
        {
            return AgorartcNative.channel_setEncryptionSecret(_channelHandler, secret);
        }

        /// <summary>
        /// Sets the built-in encryption mode.
        /// @deprecated Deprecated as of v3.1.0. Use the \ref agora::rtc::IChannel::enableEncryption "enableEncryption" instead.
        /// The Agora SDK supports built-in encryption, which is set to the `aes-128-xts` mode by default. Call this method to use other encryption modes.
        /// All users in the same channel must use the same encryption mode and password.
        /// Refer to the information related to the AES encryption algorithm on the differences between the encryption modes.
        /// @note Call the \ref IChannel::setEncryptionSecret "setEncryptionSecret" method to enable the built-in encryption function before calling this method.
        /// </summary>
        ///
        /// <param name="encryptionMode">
        /// @param encryptionMode The set encryption mode:
        /// - "aes-128-xts": (Default) 128-bit AES encryption, XTS mode.
        /// - "aes-128-ecb": 128-bit AES encryption, ECB mode.
        /// - "aes-256-xts": 256-bit AES encryption, XTS mode.
        /// - "": When encryptionMode is set as NULL, the encryption mode is set as "aes-128-xts" by default.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_setEncryptionMode(string encryptionMode)
        {
            return AgorartcNative.channel_setEncryptionMode(_channelHandler, encryptionMode);
        }

        /// <summary>
        /// Sets the role of the user, such as a host or an audience (default), before joining a channel in the interactive live streaming.
        /// This method can be used to switch the user role in the interactive live streaming after the user joins a channel.
        /// In the `LIVE_BROADCASTING` profile, when a user switches user roles after joining a channel, a successful \ref agora::rtc::IChannel::setClientRole "setClientRole" method call triggers the following callbacks:
        /// - The local client: \ref agora::rtc::IChannelEventHandler::onClientRoleChanged "onClientRoleChanged"
        /// - The remote client: \ref agora::rtc::IChannelEventHandler::onUserJoined "onUserJoined" or \ref agora::rtc::IChannelEventHandler::onUserOffline "onUserOffline" (BECOME_AUDIENCE)
        /// @note
        /// This method applies only to the `LIVE_BROADCASTING` profile.
        /// </summary>
        ///
        /// <param name="role">
        /// @param role Sets the role of the user. See #CLIENT_ROLE_TYPE.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_setClientRole(CLIENT_ROLE_TYPE role)
        {
            return AgorartcNative.channel_setClientRole(_channelHandler, role);
        }

        /// <summary>
        /// Prioritizes a remote user's stream.
        /// Use this method with the \ref IRtcEngine::setRemoteSubscribeFallbackOption "setRemoteSubscribeFallbackOption" method.
        /// If the fallback function is enabled for a subscribed stream, the SDK ensures the high-priority user gets the best possible stream quality.
        /// @note The Agora SDK supports setting `serPriority` as high for one user only.
        /// </summary>
        ///
        /// <param name="uid">
        /// @param  uid  The ID of the remote user.
        /// </param>
        ///
        /// <param name="userPriority">
        /// @param  userPriority Sets the priority of the remote user. See #PRIORITY_TYPE.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_setRemoteUserPriority(uid_t uid, PRIORITY_TYPE userPriority)
        {
            return AgorartcNative.channel_setRemoteUserPriority(_channelHandler, uid, userPriority);
        }

        /// <summary>
        /// Sets the sound position and gain of a remote user.
        /// When the local user calls this method to set the sound position of a remote user, the sound difference between the left and right channels allows the
        /// local user to track the real-time position of the remote user, creating a real sense of space. This method applies to massively multiplayer online games,
        /// such as Battle Royale games.
        /// @note
        /// - For this method to work, enable stereo panning for remote users by calling the \ref agora::rtc::IRtcEngine::enableSoundPositionIndication "enableSoundPositionIndication" method before joining a channel.
        /// - This method requires hardware support. For the best sound positioning, we recommend using a stereo speaker.
        /// </summary>
        ///
        /// <param name="uid">
        /// @param uid The ID of the remote user.
        /// </param>
        ///
        /// <param name="pan">
        /// @param pan The sound position of the remote user. The value ranges from -1.0 to 1.0:
        /// - 0.0: the remote sound comes from the front.
        /// - -1.0: the remote sound comes from the left.
        /// - 1.0: the remote sound comes from the right.
        /// </param>
        ///
        /// <param name="gain">
        /// @param gain Gain of the remote user. The value ranges from 0.0 to 100.0. The default value is 100.0 (the original gain of the remote user).
        /// The smaller the value, the less the gain.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_setRemoteVoicePosition(uid_t uid, double pan, double gain)
        {
            return AgorartcNative.channel_setRemoteVoicePosition(_channelHandler, uid, pan, gain);
        }

        /// <summary>
        /// Updates the display mode of the video view of a remote user.
        /// After initializing the video view of a remote user, you can call this method to update its rendering and mirror modes.
        /// This method affects only the video view that the local user sees.
        /// @note
        /// - Call this method after calling the \ref agora::rtc::IRtcEngine::setupRemoteVideo "setupRemoteVideo" method to initialize the remote video view.
        /// - During a call, you can call this method as many times as necessary to update the display mode of the video view of a remote user.
        /// </summary>
        ///
        /// <param name="userId">
        /// @param userId The ID of the remote user.
        /// </param>
        ///
        /// <param name="renderMode">
        /// @param renderMode The rendering mode of the remote video view. See #RENDER_MODE_TYPE.
        /// </param>
        ///
        /// <param name="mirrorMode">
        /// @param mirrorMode
        /// - The mirror mode of the remote video view. See #VIDEO_MIRROR_MODE_TYPE.
        /// - **Note**: The SDK disables the mirror mode by default.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_setRemoteRenderMode(uid_t userId, RENDER_MODE_TYPE renderMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return AgorartcNative.channel_setRemoteRenderMode(_channelHandler, userId, renderMode, mirrorMode);
        }

        /// <summary>
        /// Sets whether to receive all remote audio streams by default.
        /// You can call this method either before or after joining a channel. If you call `setDefaultMuteAllRemoteAudioStreams (true)` after joining a channel, the remote audio streams of all subsequent users are not received.
        /// @note If you want to resume receiving the audio stream, call \ref agora::rtc::IChannel::muteRemoteAudioStream "muteRemoteAudioStream (false)",
        /// and specify the ID of the remote user whose audio stream you want to receive.
        /// To receive the audio streams of multiple remote users, call `muteRemoteAudioStream (false)` as many times.
        /// Calling `setDefaultMuteAllRemoteAudioStreams (false)` resumes receiving the audio streams of subsequent users only.
        /// </summary>
        ///
        /// <param name="mute">
        /// @param mute Sets whether to receive/stop receiving all remote users' audio streams by default:
        /// - true:  Stops receiving all remote users' audio streams by default.
        /// - false: (Default) Receives all remote users' audio streams by default.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_setDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            return AgorartcNative.channel_setDefaultMuteAllRemoteAudioStreams(_channelHandler, mute ? 1 : 0);
        }

        /// <summary>
        /// Sets whether to receive all remote video streams by default.
        /// You can call this method either before or after joining a channel. If you
        /// call `setDefaultMuteAllRemoteVideoStreams (true)` after joining a channel,
        /// the remote video streams of all subsequent users are not received.
        /// @note If you want to resume receiving the video stream, call
        /// \ref agora::rtc::IChannel::muteRemoteVideoStream "muteRemoteVideoStream (false)",
        /// and specify the ID of the remote user whose video stream you want to receive.
        /// To receive the video streams of multiple remote users, call `muteRemoteVideoStream (false)`
        /// as many times. Calling `setDefaultMuteAllRemoteVideoStreams (false)` resumes
        /// receiving the video streams of subsequent users only.
        /// </summary>
        ///
        /// <param name="mute">
        /// @param mute Sets whether to receive/stop receiving all remote users' video streams by default:
        /// - true: Stop receiving all remote users' video streams by default.
        /// - false: (Default) Receive all remote users' video streams by default.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_setDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            return AgorartcNative.channel_setDefaultMuteAllRemoteVideoStreams(_channelHandler, mute ? 1 : 0);
        }

        /// <summary>
        /// Stops/Resumes receiving all remote users' audio streams.
        /// </summary>
        ///
        /// <param name="mute">
        /// @param mute Sets whether to receive/stop receiving all remote users' audio streams.
        /// - true: Stops receiving all remote users' audio streams.
        /// - false: (Default) Receives all remote users' audio streams.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_muteAllRemoteAudioStreams(bool mute)
        {
            return AgorartcNative.channel_muteAllRemoteAudioStreams(_channelHandler, mute ? 1 : 0);
        }

        /// <summary>
        /// Adjust the playback volume of the specified remote user.
        /// After joining a channel, call \ref agora::rtc::IRtcEngine::adjustPlaybackSignalVolume "adjustPlaybackSignalVolume" to adjust the playback volume of different remote users,
        /// or adjust multiple times for one remote user.
        /// @note
        /// - Call this method after joining a channel.
        /// - This method adjusts the playback volume, which is the mixed volume for the specified remote user.
        /// - This method can only adjust the playback volume of one specified remote user at a time. If you want to adjust the playback volume of several remote users,
        /// call the method multiple times, once for each remote user.
        /// </summary>
        ///
        /// <param name="userId">
        /// @param userId The user ID, which should be the same as the `uid` of \ref agora::rtc::IChannel::joinChannel "joinChannel"
        /// </param>
        ///
        /// <param name="volume">
        /// @param volume The playback volume of the voice. The value ranges from 0 to 100:
        /// - 0: Mute.
        /// - 100: Original volume.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_adjustUserPlaybackSignalVolume(uid_t userId, int volume)
        {
            return AgorartcNative.channel_adjustUserPlaybackSignalVolume(_channelHandler, userId, volume);
        }

        /// <summary>
        /// Stops/Resumes receiving a specified remote user's audio stream.
        /// @note If you called the \ref agora::rtc::IChannel::muteAllRemoteAudioStreams "muteAllRemoteAudioStreams" method and set `mute` as `true` to stop
        /// receiving all remote users' audio streams, call the `muteAllRemoteAudioStreams` method and set `mute` as `false` before calling this method.
        /// The `muteAllRemoteAudioStreams` method sets all remote audio streams, while the `muteRemoteAudioStream` method sets a specified remote audio stream.
        /// </summary>
        ///
        /// <param name="userId">
        /// @param userId The user ID of the specified remote user sending the audio.
        /// </param>
        ///
        /// <param name="mute">
        /// @param mute Sets whether to receive/stop receiving a specified remote user's audio stream:
        /// - true: Stops receiving the specified remote user's audio stream.
        /// - false: (Default) Receives the specified remote user's audio stream.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_muteRemoteAudioStream(uid_t userId, bool mute)
        {
            return AgorartcNative.channel_muteRemoteAudioStream(_channelHandler, userId, mute ? 1 : 0);
        }

        /// <summary>
        /// Stops/Resumes receiving all video stream from a specified remote user.
        /// </summary>
        ///
        /// <param name="mute">
        /// @param  mute Sets whether to receive/stop receiving all remote users' video streams:
        /// - true: Stop receiving all remote users' video streams.
        /// - false: (Default) Receive all remote users' video streams.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_muteAllRemoteVideoStreams(bool mute)
        {
            return AgorartcNative.channel_muteAllRemoteVideoStreams(_channelHandler, mute ? 1 : 0);
        }

        /// <summary>
        /// Stops/Resumes receiving the video stream from a specified remote user.
        /// @note If you called the \ref agora::rtc::IChannel::muteAllRemoteVideoStreams "muteAllRemoteVideoStreams" method and
        /// set `mute` as `true` to stop receiving all remote video streams, call the `muteAllRemoteVideoStreams` method and
        /// set `mute` as `false` before calling this method.
        /// </summary>
        ///
        /// <param name="userId">
        /// @param userId The user ID of the specified remote user.
        /// </param>
        ///
        /// <param name="mute">
        /// @param mute Sets whether to stop/resume receiving the video stream from a specified remote user:
        /// - true: Stop receiving the specified remote user's video stream.
        /// - false: (Default) Receive the specified remote user's video stream.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_muteRemoteVideoStream(uid_t userId, bool mute)
        {
            return AgorartcNative.channel_muteRemoteVideoStream(_channelHandler, userId, mute ? 1 : 0);
        }

        /// <summary>
        /// Sets the stream type of the remote video.
        /// Under limited network conditions, if the publisher has not disabled the dual-stream mode using
        /// \ref agora::rtc::IRtcEngine::enableDualStreamMode "enableDualStreamMode" (false),
        /// the receiver can choose to receive either the high-quality video stream (the high resolution, and high bitrate video stream) or
        /// the low-video stream (the low resolution, and low bitrate video stream).
        /// By default, users receive the high-quality video stream. Call this method if you want to switch to the low-video stream.
        /// This method allows the app to adjust the corresponding video stream type based on the size of the video window to
        /// reduce the bandwidth and resources.
        /// The aspect ratio of the low-video stream is the same as the high-quality video stream. Once the resolution of the high-quality video
        /// stream is set, the system automatically sets the resolution, frame rate, and bitrate of the low-video stream.
        /// The method result returns in the \ref agora::rtc::IRtcEngineEventHandler::onApiCallExecuted "onApiCallExecuted" callback.
        /// </summary>
        ///
        /// <param name="userId">
        /// @param userId The ID of the remote user sending the video stream.
        /// </param>
        ///
        /// <param name="streamType">
        /// @param streamType  Sets the video-stream type. See #REMOTE_VIDEO_STREAM_TYPE.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_setRemoteVideoStreamType(uid_t userId, REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            return AgorartcNative.channel_setRemoteVideoStreamType(_channelHandler, userId, streamType);
        }

        /// <summary>
        /// Sets the default stream type of remote videos.
        /// Under limited network conditions, if the publisher has not disabled the dual-stream mode using
        /// \ref agora::rtc::IRtcEngine::enableDualStreamMode "enableDualStreamMode" (false),
        /// the receiver can choose to receive either the high-quality video stream (the high resolution, and high bitrate video stream) or
        /// the low-video stream (the low resolution, and low bitrate video stream).
        /// By default, users receive the high-quality video stream. Call this method if you want to switch to the low-video stream.
        /// This method allows the app to adjust the corresponding video stream type based on the size of the video window to
        /// reduce the bandwidth and resources. The aspect ratio of the low-video stream is the same as the high-quality video stream.
        /// Once the resolution of the high-quality video
        /// stream is set, the system automatically sets the resolution, frame rate, and bitrate of the low-video stream.
        /// The method result returns in the \ref agora::rtc::IRtcEngineEventHandler::onApiCallExecuted "onApiCallExecuted" callback.
        /// </summary>
        ///
        /// <param name="streamType">
        /// @param streamType Sets the default video-stream type. See #REMOTE_VIDEO_STREAM_TYPE.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_setRemoteDefaultVideoStreamType(REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            return AgorartcNative.channel_setRemoteDefaultVideoStreamType(_channelHandler, streamType);
        }

        /// <summary>
        /// Publishes the local stream to a specified CDN live RTMP address.  (CDN live only.)
        /// The SDK returns the result of this method call in the \ref IRtcEngineEventHandler::onStreamPublished "onStreamPublished" callback.
        /// The \ref agora::rtc::IChannel::addPublishStreamUrl "addPublishStreamUrl" method call triggers
        /// the \ref agora::rtc::IChannelEventHandler::onRtmpStreamingStateChanged "onRtmpStreamingStateChanged" callback on the local client
        /// to report the state of adding a local stream to the CDN.
        /// @note
        /// - Ensure that the user joins the channel before calling this method.
        /// - Ensure that you enable the RTMP Converter service before using this function. See Prerequisites in the advanced guide *Push Streams to CDN*.
        /// - This method adds only one stream RTMP URL address each time it is called.
        /// </summary>
        ///
        /// <param name="url">
        /// @param url The CDN streaming URL in the RTMP format. The maximum length of this parameter is 1024 bytes. The RTMP URL address must not contain special characters, such as Chinese language characters.
        /// </param>
        ///
        /// <param name="transcodingEnabled">
        /// @param  transcodingEnabled Sets whether transcoding is enabled/disabled:
        /// - true: Enable transcoding. To [transcode](https://docs.agora.io/en/Agora%20Platform/terms?platform=All%20Platforms#transcoding) the audio or video streams when publishing them to CDN live, often used for combining the audio and video streams of multiple hosts in CDN live. If you set this parameter as `true`, ensure that you call the \ref IChannel::setLiveTranscoding "setLiveTranscoding" method before this method.
        /// - false: Disable transcoding.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// - #ERR_INVALID_ARGUMENT (2): The RTMP URL address is NULL or has a string length of 0.
        /// - #ERR_NOT_INITIALIZED (7): You have not initialized `IChannel` when publishing the stream.
        /// </returns>
        public ERROR_CODE channel_addPublishStreamUrl(string url, bool transcodingEnabled)
        {
            return AgorartcNative.channel_addPublishStreamUrl(_channelHandler, url, transcodingEnabled ? 1 : 0);
        }

        /// <summary>
        /// Removes an RTMP stream from the CDN.
        /// This method removes the RTMP URL address (added by the \ref IChannel::addPublishStreamUrl "addPublishStreamUrl" method) from a CDN live stream.
        /// The SDK returns the result of this method call in the \ref IRtcEngineEventHandler::onStreamUnpublished "onStreamUnpublished" callback.
        /// The \ref agora::rtc::IChannel::removePublishStreamUrl "removePublishStreamUrl" method call triggers
        /// the \ref agora::rtc::IChannelEventHandler::onRtmpStreamingStateChanged "onRtmpStreamingStateChanged" callback on the local client to report the state of removing an RTMP stream from the CDN.
        /// @note
        /// - This method removes only one RTMP URL address each time it is called.
        /// - The RTMP URL address must not contain special characters, such as Chinese language characters.
        /// </summary>
        ///
        /// <param name="url">
        /// @param url The RTMP URL address to be removed. The maximum length of this parameter is 1024 bytes.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_removePublishStreamUrl(string url)
        {
            return AgorartcNative.channel_removePublishStreamUrl(_channelHandler, url);
        }

        /// <summary>
        /// Sets the video layout and audio settings for CDN live. (CDN live only.)
        /// The SDK triggers the \ref agora::rtc::IChannelEventHandler::onTranscodingUpdated "onTranscodingUpdated" callback when you
        /// call the `setLiveTranscoding` method to update the transcoding setting.
        /// @note
        /// - Ensure that you enable the RTMP Converter service before using this function. See Prerequisites in the advanced guide *Push Streams to CDN*..
        /// - If you call the `setLiveTranscoding` method to set the transcoding setting for the first time, the SDK does not trigger the `onTranscodingUpdated` callback.
        /// </summary>
        ///
        /// <param name="transcoding">
        /// @param transcoding Sets the CDN live audio/video transcoding settings. See LiveTranscoding.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_setLiveTranscoding(ref LiveTranscoding transcoding)
        {
            return AgorartcNative.channel_setLiveTranscoding(_channelHandler, ref transcoding);
        }

        /// <summary>
        /// Adds a voice or video stream URL address to the interactive live streaming.
        /// The \ref IRtcEngineEventHandler::onStreamPublished "onStreamPublished" callback returns the inject status.
        /// If this method call is successful, the server pulls the voice or video stream and injects it into a live channel.
        /// This is applicable to scenarios where all audience members in the channel can watch a live show and interact with each other.
        /// The \ref agora::rtc::IChannel::addInjectStreamUrl "addInjectStreamUrl" method call triggers the following callbacks:
        /// - The local client:
        /// - \ref agora::rtc::IChannelEventHandler::onStreamInjectedStatus "onStreamInjectedStatus" , with the state of the injecting the online stream.
        /// - \ref agora::rtc::IChannelEventHandler::onUserJoined "onUserJoined" (uid: 666), if the method call is successful and the online media stream is injected into the channel.
        /// - The remote client:
        /// - \ref agora::rtc::IChannelEventHandler::onUserJoined "onUserJoined" (uid: 666), if the method call is successful and the online media stream is injected into the channel.
        /// @note
        /// - Ensure that you enable the RTMP Converter service before using this function. See Prerequisites in the advanced guide *Push Streams to CDN*.
        /// - This method applies to the Native SDK v2.4.1 and later.
        /// - This method applies to the `LIVE_BROADCASTING` profile only.
        /// - You can inject only one media stream into the channel at the same time.
        /// </summary>
        ///
        /// <param name="url">
        /// @param url The URL address to be added to the ongoing live streaming. Valid protocols are RTMP, HLS, and HTTP-FLV.
        /// - Supported audio codec type: AAC.
        /// - Supported video codec type: H264 (AVC).
        /// </param>
        ///
        /// <param name="config">
        /// @param config The InjectStreamConfig object that contains the configuration of the added voice or video stream.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// - #ERR_INVALID_ARGUMENT (2): The injected URL does not exist. Call this method again to inject the stream and ensure that the URL is valid.
        /// - #ERR_NOT_READY (3): The user is not in the channel.
        /// - #ERR_NOT_SUPPORTED (4): The channel profile is not `LIVE_BROADCASTING`. Call the \ref IRtcEngine::setChannelProfile "setChannelProfile" method and set the channel profile to `LIVE_BROADCASTING` before calling this method.
        /// - #ERR_NOT_INITIALIZED (7): The SDK is not initialized. Ensure that the IChannel object is initialized before calling this method.
        /// </returns>
        public ERROR_CODE channel_addInjectStreamUrl(string url, InjectStreamConfig config)
        {
            return AgorartcNative.channel_addInjectStreamUrl(_channelHandler, url, config);
        }

        /// <summary>
        /// Removes the voice or video stream URL address from a live streaming.
        /// This method removes the URL address (added by the \ref IChannel::addInjectStreamUrl "addInjectStreamUrl" method) from the live streaming.
        /// @note If this method is called successfully, the SDK triggers the \ref IChannelEventHandler::onUserOffline "onUserOffline" callback and returns a stream uid of 666.
        /// </summary>
        ///
        /// <param name="url">
        /// @param url Pointer to the URL address of the added stream to be removed.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_removeInjectStreamUrl(string url)
        {
            return AgorartcNative.channel_removeInjectStreamUrl(_channelHandler, url);
        }

        /// <summary>
        /// Starts to relay media streams across channels.
        ///
        /// After a successful method call, the SDK triggers the
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayStateChanged
        /// "onChannelMediaRelayStateChanged" and
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayEvent
        /// "onChannelMediaRelayEvent" callbacks, and these callbacks return the
        /// state and events of the media stream relay.
        /// - If the
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayStateChanged
        /// "onChannelMediaRelayStateChanged" callback returns
        /// #RELAY_STATE_RUNNING (2) and #RELAY_OK (0), and the
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayEvent
        /// "onChannelMediaRelayEvent" callback returns
        /// #RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL (4), the host starts
        /// sending data to the destination channel.
        /// - If the
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayStateChanged
        /// "onChannelMediaRelayStateChanged" callback returns
        /// #RELAY_STATE_FAILURE (3), an exception occurs during the media stream
        /// relay.
        ///
        /// @note
        /// - Call this method after the \ref joinChannel() "joinChannel" method.
        /// - This method takes effect only when you are a host in a
        /// `LIVE_BROADCASTING` channel.
        /// - After a successful method call, if you want to call this method
        /// again, ensure that you call the
        /// \ref stopChannelMediaRelay() "stopChannelMediaRelay" method to quit the
        /// current relay.
        /// - Contact sales-us@agora.io before implementing this function.
        /// - We do not support string user accounts in this API.
        ///
        /// </summary>
        ///
        /// <param name="configuration">
        /// @param configuration The configuration of the media stream relay:
        /// ChannelMediaRelayConfiguration.
        ///
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_startChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            return AgorartcNative.channel_startChannelMediaRelay(_channelHandler, configuration);
        }

        /// <summary>
        /// Updates the channels for media stream relay.
        ///
        /// After a successful
        /// \ref startChannelMediaRelay() "startChannelMediaRelay" method call, if
        /// you want to relay the media stream to more channels, or leave the
        /// current relay channel, you can call the
        /// \ref updateChannelMediaRelay() "updateChannelMediaRelay" method.
        ///
        /// After a successful method call, the SDK triggers the
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayEvent
        /// "onChannelMediaRelayEvent" callback with the
        /// #RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL (7) state code.
        ///
        /// @note
        /// Call this method after the
        /// \ref startChannelMediaRelay() "startChannelMediaRelay" method to update
        /// the destination channel.
        ///
        /// </summary>
        ///
        /// <param name="configuration">
        /// @param configuration The media stream relay configuration:
        /// ChannelMediaRelayConfiguration.
        ///
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_updateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            return AgorartcNative.channel_updateChannelMediaRelay(_channelHandler, configuration);
        }

        /// <summary>
        /// Stops the media stream relay.
        ///
        /// Once the relay stops, the host quits all the destination
        /// channels.
        ///
        /// After a successful method call, the SDK triggers the
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayStateChanged
        /// "onChannelMediaRelayStateChanged" callback. If the callback returns
        /// #RELAY_STATE_IDLE (0) and #RELAY_OK (0), the host successfully
        /// stops the relay.
        ///
        /// @note
        /// If the method call fails, the SDK triggers the
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayStateChanged
        /// "onChannelMediaRelayStateChanged" callback with the
        /// #RELAY_ERROR_SERVER_NO_RESPONSE (2) or
        /// #RELAY_ERROR_SERVER_CONNECTION_LOST (8) state code. You can leave the
        /// channel by calling the \ref leaveChannel() "leaveChannel" method, and
        /// the media stream relay automatically stops.
        ///
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_stopChannelMediaRelay()
        {
            return AgorartcNative.channel_stopChannelMediaRelay(_channelHandler);
        }

        /// <summary>
        /// Creates a data stream.
        /// Each user can create up to five data streams during the lifecycle of the IChannel.
        /// @note Set both the `reliable` and `ordered` parameters to `true` or `false`. Do not set one as `true` and the other as `false`.
        /// </summary>
        ///
        /// <param name="streamId">
        /// @param streamId The ID of the created data stream.
        /// </param>
        ///
        /// <param name="reliable">
        /// @param reliable Sets whether or not the recipients are guaranteed to receive the data stream from the sender within five seconds:
        /// - true: The recipients receive the data stream from the sender within five seconds. If the recipient does not receive the data stream within five seconds,
        /// an error is reported to the application.
        /// - false: There is no guarantee that the recipients receive the data stream within five seconds and no error message is reported for
        /// any delay or missing data stream.
        /// </param>
        ///
        /// <param name="ordered">
        /// @param ordered Sets whether or not the recipients receive the data stream in the sent order:
        /// - true: The recipients receive the data stream in the sent order.
        /// - false: The recipients do not receive the data stream in the sent order.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - Returns 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_createDataStream(IntPtr streamId, bool reliable, bool ordered)
        {
            return AgorartcNative.channel_createDataStream(_channelHandler, streamId, reliable ? 1 : 0,
                ordered ? 1 : 0);
        }

        /// <summary>
        /// Sends data stream messages to all users in a channel.
        /// The SDK has the following restrictions on this method:
        /// - Up to 30 packets can be sent per second in a channel with each packet having a maximum size of 1 kB.
        /// - Each client can send up to 6 kB of data per second.
        /// - Each user can have up to five data streams simultaneously.
        /// A successful \ref agora::rtc::IChannel::sendStreamMessage "sendStreamMessage" method call triggers
        /// the \ref agora::rtc::IChannelEventHandler::onStreamMessage "onStreamMessage" callback on the remote client, from which the remote user gets the stream message.
        /// A failed \ref agora::rtc::IChannel::sendStreamMessage "sendStreamMessage" method call triggers
        /// the \ref agora::rtc::IChannelEventHandler::onStreamMessageError "onStreamMessage" callback on the remote client.
        /// @note
        /// - This method applies only to the `COMMUNICATION` profile or to the hosts in the `LIVE_BROADCASTING` profile. If an audience in the `LIVE_BROADCASTING` profile calls this method, the audience may be switched to a host.
        /// - Ensure that you have created the data stream using \ref agora::rtc::IChannel::createDataStream "createDataStream" before calling this method.
        /// </summary>
        ///
        /// <param name="streamId">
        /// @param  streamId  The ID of the sent data stream, returned in the \ref IChannel::createDataStream "createDataStream" method.
        /// </param>
        ///
        /// <param name="data">
        /// @param data The sent data.
        /// </param>
        ///
        /// <param name="length">
        /// @param length The length of the sent data.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE channel_sendStreamMessage(int streamId, string data, long length)
        {
            return AgorartcNative.channel_sendStreamMessage(_channelHandler, streamId, data, length);
        }

        /// <summary>
        /// Gets the current connection state of the SDK.
        /// </summary>
        ///
        /// <returns>
        /// @return #CONNECTION_STATE_TYPE.
        /// </returns>
        public CONNECTION_STATE_TYPE channel_getConnectionState()
        {
            return AgorartcNative.channel_getConnectionState(_channelHandler);
        }

        public void ReleaseChannel()
        {
            AgorartcNative.releaseChannel(_channelHandler);
            NativeRtcChannelEventHandler.RemoveChannel(_channelId);
            _channelHandler = IntPtr.Zero;
            channelEventHandler = null;
            AgoraRtcEngine.CreateRtcEngine().ReleaseChannel(_channelId);
        }

        ~AgoraRtcChannel()
        {
            Dispose(false);
        }
    }
}
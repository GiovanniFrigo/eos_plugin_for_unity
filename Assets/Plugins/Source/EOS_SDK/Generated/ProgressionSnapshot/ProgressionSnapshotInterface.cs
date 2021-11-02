// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.ProgressionSnapshot
{
	public sealed partial class ProgressionSnapshotInterface : Handle
	{
		public ProgressionSnapshotInterface()
		{
		}

		public ProgressionSnapshotInterface(System.IntPtr innerHandle) : base(innerHandle)
		{
		}

		public const int AddprogressionApiLatest = 1;

		public const int BeginsnapshotApiLatest = 1;

		public const int DeletesnapshotApiLatest = 1;

		public const int EndsnapshotApiLatest = 1;

		public const int InvalidProgressionsnapshotid = 0;

		public const int SubmitsnapshotApiLatest = 1;

		/// <summary>
		/// Stores a Key/Value pair in memory for a given snapshot.
		/// If multiple calls happen with the same key, the last invocation wins, overwriting the previous value for that
		/// given key.
		/// 
		/// The order in which the Key/Value pairs are added is stored as is for later retrieval/display.
		/// Ideally, you would make multiple calls to AddProgression() followed by a single call to SubmitSnapshot().
		/// </summary>
		/// <returns>
		/// <see cref="Result.Success" /> when successful; otherwise, <see cref="Result.NotFound" />
		/// </returns>
		public Result AddProgression(AddProgressionOptions options)
		{
			var optionsAddress = System.IntPtr.Zero;
			Helper.TryMarshalSet<AddProgressionOptionsInternal, AddProgressionOptions>(ref optionsAddress, options);

			var funcResult = Bindings.EOS_ProgressionSnapshot_AddProgression(InnerHandle, optionsAddress);

			Helper.TryMarshalDispose(ref optionsAddress);

			return funcResult;
		}

		/// <summary>
		/// Creates a new progression-snapshot resource for a given user.
		/// </summary>
		/// <param name="options">Object containing properties that identifies the PUID this Snapshot will belong to.</param>
		/// <param name="outSnapshotId">A progression-snapshot identifier output parameter. Use that identifier to reference the snapshot in the other APIs.</param>
		/// <returns>
		/// <see cref="Result.Success" /> when successful.
		/// <see cref="Result.ProgressionSnapshotSnapshotIdUnavailable" /> when no IDs are available. This is irrecoverable state.
		/// </returns>
		public Result BeginSnapshot(BeginSnapshotOptions options, out uint outSnapshotId)
		{
			var optionsAddress = System.IntPtr.Zero;
			Helper.TryMarshalSet<BeginSnapshotOptionsInternal, BeginSnapshotOptions>(ref optionsAddress, options);

			outSnapshotId = Helper.GetDefault<uint>();

			var funcResult = Bindings.EOS_ProgressionSnapshot_BeginSnapshot(InnerHandle, optionsAddress, ref outSnapshotId);

			Helper.TryMarshalDispose(ref optionsAddress);

			return funcResult;
		}

		/// <summary>
		/// Wipes out all progression data for the given user from the service. However, any previous progression data that haven't
		/// been submitted yet are retained.
		/// </summary>
		public void DeleteSnapshot(DeleteSnapshotOptions options, object clientData, OnDeleteSnapshotCallback completionDelegate)
		{
			var optionsAddress = System.IntPtr.Zero;
			Helper.TryMarshalSet<DeleteSnapshotOptionsInternal, DeleteSnapshotOptions>(ref optionsAddress, options);

			var clientDataAddress = System.IntPtr.Zero;

			var completionDelegateInternal = new OnDeleteSnapshotCallbackInternal(OnDeleteSnapshotCallbackInternalImplementation);
			Helper.AddCallback(ref clientDataAddress, clientData, completionDelegate, completionDelegateInternal);

			Bindings.EOS_ProgressionSnapshot_DeleteSnapshot(InnerHandle, optionsAddress, clientDataAddress, completionDelegateInternal);

			Helper.TryMarshalDispose(ref optionsAddress);
		}

		/// <summary>
		/// Cleans up and releases resources associated with the given progression snapshot identifier.
		/// </summary>
		/// <returns>
		/// <see cref="Result.Success" /> when successful; otherwise, <see cref="Result.NotFound" />
		/// </returns>
		public Result EndSnapshot(EndSnapshotOptions options)
		{
			var optionsAddress = System.IntPtr.Zero;
			Helper.TryMarshalSet<EndSnapshotOptionsInternal, EndSnapshotOptions>(ref optionsAddress, options);

			var funcResult = Bindings.EOS_ProgressionSnapshot_EndSnapshot(InnerHandle, optionsAddress);

			Helper.TryMarshalDispose(ref optionsAddress);

			return funcResult;
		}

		/// <summary>
		/// Saves the previously added Key/Value pairs of a given Snapshot to the service.
		/// 
		/// Note: This will overwrite any prior progression data stored with the service that's associated with the user.
		/// </summary>
		public void SubmitSnapshot(SubmitSnapshotOptions options, object clientData, OnSubmitSnapshotCallback completionDelegate)
		{
			var optionsAddress = System.IntPtr.Zero;
			Helper.TryMarshalSet<SubmitSnapshotOptionsInternal, SubmitSnapshotOptions>(ref optionsAddress, options);

			var clientDataAddress = System.IntPtr.Zero;

			var completionDelegateInternal = new OnSubmitSnapshotCallbackInternal(OnSubmitSnapshotCallbackInternalImplementation);
			Helper.AddCallback(ref clientDataAddress, clientData, completionDelegate, completionDelegateInternal);

			Bindings.EOS_ProgressionSnapshot_SubmitSnapshot(InnerHandle, optionsAddress, clientDataAddress, completionDelegateInternal);

			Helper.TryMarshalDispose(ref optionsAddress);
		}

		[MonoPInvokeCallback(typeof(OnDeleteSnapshotCallbackInternal))]
		internal static void OnDeleteSnapshotCallbackInternalImplementation(System.IntPtr data)
		{
			OnDeleteSnapshotCallback callback;
			DeleteSnapshotCallbackInfo callbackInfo;
			if (Helper.TryGetAndRemoveCallback<OnDeleteSnapshotCallback, DeleteSnapshotCallbackInfoInternal, DeleteSnapshotCallbackInfo>(data, out callback, out callbackInfo))
			{
				callback(callbackInfo);
			}
		}

		[MonoPInvokeCallback(typeof(OnSubmitSnapshotCallbackInternal))]
		internal static void OnSubmitSnapshotCallbackInternalImplementation(System.IntPtr data)
		{
			OnSubmitSnapshotCallback callback;
			SubmitSnapshotCallbackInfo callbackInfo;
			if (Helper.TryGetAndRemoveCallback<OnSubmitSnapshotCallback, SubmitSnapshotCallbackInfoInternal, SubmitSnapshotCallbackInfo>(data, out callback, out callbackInfo))
			{
				callback(callbackInfo);
			}
		}
	}
}
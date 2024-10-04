﻿using System.Threading.Tasks;
using Amazon.S3;
using FluentStorage.Blobs;

namespace FluentStorage.AWS.Blobs {
	/// <summary>
	/// Provides access to native operations
	/// </summary>
	public interface IAwsS3BlobStorage : IBlobStorage {
		/// <summary>
		/// Returns reference to the native AWS S3 blob client.
		/// </summary>
		IAmazonS3 NativeBlobClient { get; }

		/// <summary>
		/// Return bucket name.
		/// </summary>
		string BucketName { get; }

		/// <summary>
		/// Get presigned url for upload object to Blob Storage.
		/// </summary>
		Task<string> GetUploadUrlAsync(string fullPath, string mimeType, int expiresInSeconds = 86000);

		/// <summary>
		/// Get presigned url for download object from Blob Storage.
		/// </summary>
		Task<string> GetDownloadUrlAsync(string fullPath, string mimeType, int expiresInSeconds = 86000);

		/// <summary>
		/// Get presigned url for requested operation with Blob Storage.
		/// </summary>
		Task<string> GetPresignedUrlAsync(string fullPath, string mimeType, int expiresInSeconds, HttpVerb verb);

		/// <summary>
		/// Set acl for object.
		/// </summary>
		/// <param name="fullPath"></param>
		/// <param name="acl"></param>
		Task SetAcl(string fullPath, string acl);
	}
}

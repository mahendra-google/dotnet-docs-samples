// Copyright 2021 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.IO;
using Xunit;

[Collection(nameof(StorageFixture))]
public class CopyFileArchivedGenerationTest
{
    private readonly StorageFixture _fixture;

    public CopyFileArchivedGenerationTest(StorageFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void CopyFileArchivedGeneration()
    {
        UploadFileSample uploadFileSample = new UploadFileSample();
        BucketEnableVersioningSample bucketEnableVersioningSample = new BucketEnableVersioningSample();
        GetMetadataSample getMetadataSample = new GetMetadataSample();
        DownloadFileSample downloadFileSample = new DownloadFileSample();
        CopyFileArchivedGenerationSample copyFileArchivedGenerationSample = new CopyFileArchivedGenerationSample();
        BucketDisableVersioningSample bucketDisableVersioningSample = new BucketDisableVersioningSample();

        var sourceBucketName = _fixture.GenerateBucketName();
        _fixture.CreateBucket(sourceBucketName, multiVersion: false, softDelete: false, registerForDeletion: true);

        var destinationBucketName = _fixture.GenerateBucketName();
        _fixture.CreateBucket(destinationBucketName, multiVersion: false, softDelete: false, registerForDeletion: true);

        var objectName =$"{_fixture.GenerateName()}.txt";
        var copiedObjectName = $"{_fixture.GenerateName()}.txt";

        // Enable bucket versioning
        bucketEnableVersioningSample.BucketEnableVersioning(sourceBucketName);

        // Uploaded for the first time
        uploadFileSample.UploadFile(sourceBucketName, _fixture.FilePath, objectName);

        // Get generation of first version of the file
        var obj = getMetadataSample.GetMetadata(sourceBucketName, objectName);
        var fileArchivedGeneration = obj.Generation;

        // Upload again to archive previous generation.
        uploadFileSample.UploadFile(sourceBucketName, "Resources/HelloDownloadCompleteByteRange.txt", objectName);

        // Get generation of second version of the file
        obj = getMetadataSample.GetMetadata(sourceBucketName, objectName);
        var fileCurrentGeneration = obj.Generation;


        _fixture.CollectArchivedFiles(sourceBucketName, objectName, fileArchivedGeneration);
        _fixture.CollectArchivedFiles(sourceBucketName, objectName, fileCurrentGeneration);

        try
        {
            // Copy first version of the file to new bucket.
            copyFileArchivedGenerationSample.CopyFileArchivedGeneration(sourceBucketName, objectName,
                destinationBucketName, copiedObjectName, fileArchivedGeneration);

            // Download copied file
            downloadFileSample.DownloadFile(destinationBucketName, copiedObjectName, copiedObjectName);

            // Match file contents with first version of the file
            Assert.Equal(File.ReadAllText(_fixture.FilePath), File.ReadAllText(copiedObjectName));
        }
        finally
        {
            File.Delete(copiedObjectName);

            // Disable bucket versioning
            bucketDisableVersioningSample.BucketDisableVersioning(sourceBucketName);
        }
    }
}

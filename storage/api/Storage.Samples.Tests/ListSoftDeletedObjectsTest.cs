// Copyright 2025 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License").
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at 
//
// https://www.apache.org/licenses/LICENSE-2.0 
//
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and 
// limitations under the License.

using System;
using Xunit;

[Collection(nameof(StorageFixture))]
public class ListSoftDeletedObjectsTest
{
    private readonly StorageFixture _fixture;

    public ListSoftDeletedObjectsTest(StorageFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void ListSoftDeletedObjects()
    {
        ListSoftDeletedObjectsSample listSoftDeletedObjects = new ListSoftDeletedObjectsSample();
        UploadObjectFromMemorySample uploadObjectFromMemory = new UploadObjectFromMemorySample();
        var bucketName = _fixture.GenerateBucketName();
        _fixture.CreateBucket(bucketName, multiVersion: false, softDelete: false, registerForDeletion: true);
        var objectName = Guid.NewGuid().ToString();
        var objectContents = Guid.NewGuid().ToString();
        var testObjectName = Guid.NewGuid().ToString();
        var testObjectContents = Guid.NewGuid().ToString();
        uploadObjectFromMemory.UploadObjectFromMemory(bucketName, objectName, objectContents);
        uploadObjectFromMemory.UploadObjectFromMemory(bucketName, testObjectName, testObjectContents);
        _fixture.Client.DeleteObject(bucketName, objectName);
        _fixture.Client.DeleteObject(bucketName, testObjectName);
        var objects = listSoftDeletedObjects.ListSoftDeletedObjects(bucketName);
        Assert.All(objects, c => Assert.Contains(objectName, c.Name) && Assert.Contains(testObjectName, c.Name));
    }
}

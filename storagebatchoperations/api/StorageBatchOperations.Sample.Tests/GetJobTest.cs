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

using Google.Api.Gax.ResourceNames;
using System;
using Xunit;

[Collection(nameof(StorageFixture))]
public class GetJobTest
{
    private readonly StorageFixture _fixture;

    public GetJobTest(StorageFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void GetJob()
    {
        GetJobSample getJob = new GetJobSample();
        var bucketName = _fixture.GenerateBucketName();
        _fixture.CreateBucket(bucketName);
        LocationName parent = LocationName.FromProjectLocation(_fixture.ProjectId, _fixture.TestLocation);
        getJob.GetJob(parent.ToString());
        //Assert.Contains(jobs, c => c.Name == bucketName);
    }
}

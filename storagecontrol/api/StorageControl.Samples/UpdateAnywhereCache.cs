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

// [START storage_control_update_anywhere_cache]

using Google.Cloud.Storage.Control.V2;
using Google.LongRunning;
using Google.Protobuf.WellKnownTypes;

public class UpdateAnywhereCacheSample
{
    /// <summary>Update an Anywhere Cache</summary>
    public void UpdateAnywhereCache()
    {
        // Create client
        StorageControlClient storageControlClient = StorageControlClient.Create();
        // Initialize request argument(s)
        AnywhereCache anywhereCache = new AnywhereCache();
        FieldMask updateMask = new FieldMask();
        // Make the request
        Operation<AnywhereCache, UpdateAnywhereCacheMetadata> response = storageControlClient.UpdateAnywhereCache(anywhereCache, updateMask);

        // Poll until the returned long-running operation is complete
        Operation<AnywhereCache, UpdateAnywhereCacheMetadata> completedResponse = response.PollUntilCompleted();
        // Retrieve the operation result
        AnywhereCache result = completedResponse.Result;

        // Or get the name of the operation
        string operationName = response.Name;
        // This name can be stored, then the long-running operation retrieved later by name
        Operation<AnywhereCache, UpdateAnywhereCacheMetadata> retrievedResponse = storageControlClient.PollOnceUpdateAnywhereCache(operationName);
        // Check if the retrieved long-running operation has completed
        if (retrievedResponse.IsCompleted)
        {
            // If it has completed, then access the result
            AnywhereCache retrievedResult = retrievedResponse.Result;
        }
    }
}
// [END storage_control_update_anywhere_cache]

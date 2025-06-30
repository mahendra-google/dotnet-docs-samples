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

// [START storage_control_disable_anywhere_cache]

using Google.Cloud.Storage.Control.V2;

public class DisableAnywhereCacheSample
{
    /// <summary>Disable an Anywhere Cache</summary>
    public void DisableAnywhereCache()
    {
        // Create client
        StorageControlClient storageControlClient = StorageControlClient.Create();
        // Initialize request argument(s)
        string name = "projects/[PROJECT]/buckets/[BUCKET]/anywhereCaches/[ANYWHERE_CACHE]";
        // Make the request
        AnywhereCache response = storageControlClient.DisableAnywhereCache(name);
    }
}
// [END storage_control_disable_anywhere_cache]

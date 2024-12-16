using Advent_Of_Code_2024_.Net.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Advent_Of_Code_2024_.Net.Day9
{
    internal static class DiskFragmenter
    {
        private const int EMPTY_DISK_FILE = -1;
        /// <summary>
        /// Task1 of the Disk Fragmenter task
        /// </summary>
        /// <param name="filesAndFreeSpace"></param>
        /// <returns></returns>
        public static long GetArrangedFilesCheckSum(string filesAndFreeSpace)
        {
            Dictionary<int, int> diskFileIds = getMemoryRepresentation(filesAndFreeSpace);
            int leftPointer = 0;
            int rightPointer = diskFileIds.Count - 1;
            long checksum = 0;
            while (leftPointer < rightPointer)
            {
                if (diskFileIds[leftPointer] != EMPTY_DISK_FILE)
                {
                    checksum += leftPointer * diskFileIds[leftPointer];
                    leftPointer++;
                    continue;
                }
                if (diskFileIds[rightPointer] == EMPTY_DISK_FILE)
                {
                    rightPointer--;
                    continue;
                }

                int temp = diskFileIds[leftPointer];
                diskFileIds[leftPointer] = diskFileIds[rightPointer];
                diskFileIds[rightPointer] = temp;

                checksum += leftPointer * diskFileIds[leftPointer];
                rightPointer--;
                leftPointer++;
            }

            if (leftPointer == rightPointer)
            {
                checksum += leftPointer * diskFileIds[leftPointer];
            }

            return checksum;
        }

        /// <summary>
        /// Task2 of the Disk Fragmenter task
        /// </summary>
        /// <param name="filesAndFreeSpace"></param>
        /// <returns></returns>
        public static long GetArrangedFilesTogetherCheckSum(string filesAndFreeSpace)
        {
            Dictionary<int, int> diskFileIds = getMemoryRepresentation(filesAndFreeSpace);
            int leftPointer = 0;
            int rightPointer = diskFileIds.Count - 1;
            while (leftPointer < rightPointer)
            {
                if (diskFileIds[leftPointer] != EMPTY_DISK_FILE)
                {
                    leftPointer++;
                    continue;
                }
                if (diskFileIds[rightPointer] == EMPTY_DISK_FILE)
                {
                    rightPointer--;
                    continue;
                }

                int fileSize = 1;
                for (int i = rightPointer-1; i > leftPointer; i--)
                {
                    if(diskFileIds[i] != diskFileIds[rightPointer])
                    {
                        break;
                    }
                    fileSize += 1;
                }

                int nextFittingMemoryIndex = findNextFittingMemory(diskFileIds, leftPointer, rightPointer, fileSize);
                if (nextFittingMemoryIndex < 0)
                {
                    rightPointer -= fileSize;
                    continue;
                }

                for (int i = 0; i < fileSize; i++)
                {
                    int temp = diskFileIds[nextFittingMemoryIndex];
                    diskFileIds[nextFittingMemoryIndex] = diskFileIds[rightPointer];
                    diskFileIds[rightPointer] = temp;

                    rightPointer--;
                    nextFittingMemoryIndex++;
                }
            }

            long checksum = 0;
            foreach (var x in diskFileIds)
            {
                if (x.Value != EMPTY_DISK_FILE)
                {
                    checksum += x.Key * x.Value;
                }
            }

            return checksum;
        }

        private static int findNextFittingMemory(Dictionary<int, int> diskFileIds, int leftPointer, int rightPointer, int fileSize)
        {
            int freeMemorySize = 0;
            for(int i = leftPointer; i<rightPointer; i++)
            {
                if (diskFileIds[i] == EMPTY_DISK_FILE)
                {
                    freeMemorySize++;
                    if (freeMemorySize >= fileSize)
                    {
                        return i - freeMemorySize + 1;
                    }
                }
                else
                {
                    freeMemorySize = 0;
                }
            }

            return -1;
        }

        private static Dictionary<int, int> getMemoryRepresentation(string filesAndFreeSpace)
        {
            int lastFileId = 0;
            int diskId = 0;
            Dictionary<int, int> diskFileIds = new Dictionary<int, int>(); // display empty space as -1

            for (int i = 0; i < filesAndFreeSpace.Length; i++)
            {
                int size = int.Parse(filesAndFreeSpace[i].ToString());
                if (size == 0)
                {
                    continue;
                }

                int diskFile = EMPTY_DISK_FILE;
                if (i % 2 == 0)
                {
                    diskFile = lastFileId;
                    lastFileId++;
                }

                for (int j = 0; j < size; j++)
                {
                    diskFileIds.Add(diskId, diskFile);
                    diskId++;
                }
            }

            return diskFileIds;
        }
    }
}

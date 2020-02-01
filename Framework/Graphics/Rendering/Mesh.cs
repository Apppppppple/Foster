﻿using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Foster.Framework
{
    /// <summary>
    /// A Mesh used for Rendering
    /// </summary>
    public class Mesh : IDisposable
    {

        public abstract class Platform
        {
            protected internal abstract void UploadVertices<T>(ReadOnlySequence<T> vertices, VertexFormat format);
            protected internal abstract void UploadInstances<T>(ReadOnlySequence<T> instances, VertexFormat format);
            protected internal abstract void UploadIndices(ReadOnlySequence<int> indices);
            protected internal abstract void Dispose();
        }

        /// <summary>
        /// A reference to the internal platform implementation of the Mesh
        /// </summary>
        public readonly Platform Implementation;

        /// <summary>
        /// Number of Vertices in the Mesh
        /// </summary>
        public int VertexCount { get; private set; }

        /// <summary>
        /// Number of Indices in the Mesh
        /// </summary>
        public int IndexCount { get; private set; }

        /// <summary>
        /// Number of Instances in the Mesh
        /// </summary>
        public int InstanceCount { get; private set; }

        /// <summary>
        /// The Number of Triangle Elements in the Mesh (IndicesCount / 3)
        /// </summary>
        public int ElementCount => IndexCount / 3;

        /// <summary>
        /// Gets the Vertex Format, or null if never set
        /// </summary>
        public VertexFormat? VertexFormat { get; private set; } = null;

        /// <summary>
        /// Gets the Instance Format, or null if never set
        /// </summary>
        public VertexFormat? InstanceFormat { get; private set; } = null;

        public Mesh()
        {
            Implementation = App.Graphics.CreateMesh();
        }

        public Mesh(Graphics graphics)
        {
            Implementation = graphics.CreateMesh();
        }

        public void SetVertices<T>(T[] vertices) where T : struct, IVertex
        {
            SetVertices(new ReadOnlySequence<T>(vertices), default(T).Format);
        }

        public void SetVertices<T>(ReadOnlyMemory<T> vertices) where T : struct, IVertex
        {
            SetVertices(new ReadOnlySequence<T>(vertices), default(T).Format);
        }

        public void SetVertices<T>(ReadOnlySequence<T> vertices) where T : struct, IVertex
        {
            SetVertices(vertices, default(T).Format);
        }

        public void SetVertices<T>(ReadOnlyMemory<T> vertices, VertexFormat format)
        {
            SetVertices(new ReadOnlySequence<T>(vertices), format);
        }

        public void SetVertices<T>(ReadOnlySequence<T> vertices, VertexFormat format)
        {
            VertexCount = (int)vertices.Length;
            VertexFormat = format ?? throw new Exception("Vertex Format cannot be null");

            Implementation.UploadVertices(vertices, VertexFormat);
        }

        public void SetIndices(int[] indices)
        {
            SetIndices(new ReadOnlySequence<int>(indices));
        }

        public void SetIndices(ReadOnlyMemory<int> indices)
        {
            SetIndices(new ReadOnlySequence<int>(indices));
        }

        public void SetIndices(ReadOnlySequence<int> indices)
        {
            IndexCount = (int)indices.Length;
            Implementation.UploadIndices(indices);
        }

        public void SetInstances<T>(T[] vertices) where T : struct, IVertex
        {
            SetInstances(new ReadOnlySequence<T>(vertices), default(T).Format);
        }

        public void SetInstances<T>(ReadOnlyMemory<T> vertices) where T : struct, IVertex
        {
            SetInstances(new ReadOnlySequence<T>(vertices), default(T).Format);
        }

        public void SetInstances<T>(ReadOnlyMemory<T> vertices, VertexFormat format)
        {
            SetInstances(new ReadOnlySequence<T>(vertices), format);
        }

        public void SetInstances<T>(ReadOnlySequence<T> vertices) where T : struct, IVertex
        {
            SetInstances(vertices, default(T).Format);
        }

        public void SetInstances<T>(ReadOnlySequence<T> vertices, VertexFormat format)
        {
            InstanceCount = (int)vertices.Length;
            InstanceFormat = format ?? throw new Exception("Vertex Format cannot be null");

            Implementation.UploadInstances(vertices, InstanceFormat);
        }

        public void Dispose()
        {
            Implementation.Dispose();
        }
    }
}

﻿using System;
using System.Collections.Generic;

namespace ArucoUnity.Utilities
{
    /// <summary>
    /// Configurable and startable controller. It can have other configurable controllers as dependencies. They must
    /// have started before starting this controller. They stop this controller when at least one of them stops.
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Called when the controller is configured.
        /// </summary>
        event Action<IController> Configured;

        /// <summary>
        /// Called when the controller is configured and ready to be started, when all its dependencies started.
        /// </summary>
        event Action<IController> Ready;

        /// <summary>
        /// Called when the controller is started.
        /// </summary>
        event Action<IController> Started;

        /// <summary>
        /// Called when the controller is stopped.
        /// </summary>
        event Action<IController> Stopped;

        /// <summary>
        /// Gets or sets if configuring and starting automatically when when all dependencies started. Manually
        /// configure and start by calling <see cref="Configure"/> and <see cref="StartController"/>.
        /// </summary>
        bool AutoStart { get; set; }

        /// <summary>
        /// Gets if the controller is configured.
        /// </summary>
        bool IsConfigured { get; }

        /// <summary>
        /// Gets if the controller is ready to be started when all dependencies have started.
        /// </summary>
        bool IsReady { get; }

        /// <summary>
        /// Gets if the controller is started.
        /// </summary>
        bool IsStarted { get; }

        /// <summary>
        /// Add a new dependency. The controller must be stopped.
        /// </summary>
        void AddDependency(IController dependency);

        /// <summary>
        /// Remove a dependency. The controller must be stopped.
        /// </summary>
        void RemoveDependency(IController dependency);

        /// <summary>
        /// Gets the list of the dependencies.
        /// </summary>
        List<IController> GetDependencies();

        /// <summary>
        /// Configures the controller and calls the <see cref="Configured"/> event. Properties must be set and the
        /// controller must be stopped.
        /// </summary>
        void Configure();

        /// <summary>
        /// Starts the controller and calls the <see cref="Started"/> event. The controller must be configured, ready and
        /// stopped.
        /// </summary>
        void StartController();

        /// <summary>
        /// Stops the controller and calls the <see cref="Stopped"/> event. The controller must be configured and started.
        /// </summary>
        void StopController();
    }
}
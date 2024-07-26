using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class ObjectiveKillEnemies : Objective
    {

        int m_KillTotal;

        protected override void Start()
        {
            base.Start();

            EventManager.AddListener<EnemyKillEvent>(OnEnemyKilled);

            // set a title and description specific for this type of objective, if it hasn't one
            if (string.IsNullOrEmpty(Title))
                Title = "Eliminate all the enemies";

            if (string.IsNullOrEmpty(Description))
                Description = GetUpdatedCounterAmount();
        }

        void OnEnemyKilled(EnemyKillEvent evt)
        {
            if (IsCompleted)
                return;
            m_KillTotal++;

        }

        string GetUpdatedCounterAmount()
        {
            return m_KillTotal.ToString();
        }

        void OnDestroy()
        {
            EventManager.RemoveListener<EnemyKillEvent>(OnEnemyKilled);
        }
    }
}
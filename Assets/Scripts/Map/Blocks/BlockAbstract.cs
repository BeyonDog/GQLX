using UnityEngine;

namespace GQLX.Game.Map.Block
{
    [System.Serializable]
    public struct BlockData
    {
        public string blockName;
        public int data;

        public BlockData(string blockName, int data)
        {
            this.blockName = blockName;
            this.data = data;
        }
    }

    public abstract class BlockAbstract
    {
        // ���÷����Ĭ������
        public static bool passable = true; // ��ͨ����
        public static bool trigger = false; // ������

        /// <summary>
        /// <list type="table">
        /// <item>����Ұ��»�����ʱ����</item>
        /// <item>�󲿷�����¶������з�Ӧ����˻�����Ϊ��log</item>
        /// <item>����ؼǵ�Base.Interact()�Է���debug</item>
        /// </list>
        /// </summary>
        public virtual void Interact()
        {
            Debug.Log($"Interact with\"{GetType()}\"");
        }

        /// <summary>
        /// <list type="table">
        /// <item>�����Trigger=True,�ҵ���ҽ��뷽��ʱ����</item>
        /// <item>��ǵ���Trigger����ΪTrueʱ���ظú���</item>
        /// </list>
        /// </summary>
        public virtual void Trigger()
        {
            Debug.LogWarning($"Trigger with \"{GetType()}\", BUT YOU FORGET OVERRIDE \"Trigger()\"");
        }
    }
}
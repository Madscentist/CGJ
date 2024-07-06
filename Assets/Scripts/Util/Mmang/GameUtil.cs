using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mmang
{
    public static class GameUtil
    {
        public static IEnumerator WaitSeconds(float seconds)
        {
            while (seconds > 0)
            {
                seconds -= Time.deltaTime;
                yield return null;
            }
        }

        #region 随机坐标
        /// <summary>
        /// 返回三角形区域中的随机点
        /// </summary>
        /// <param name="a">点A</param>
        /// <param name="b">点B</param>
        /// <param name="c">点C</param>
        /// <returns></returns>
        public static Vector2 GetRandomPointInTriangle(Vector2 a, Vector2 b, Vector2 c)
        {
            float rand1 = Random.Range(0f, 1f);
            float rand2 = Random.Range(0f, 1f);
            float sqrRand1 = Mathf.Sqrt(rand1);
            return (1 - sqrRand1) * a + sqrRand1 * (1 - rand2) * b + sqrRand1 * rand2 * c;
        }

        /// <summary>
        /// 返回圆形区域中的随机点
        /// </summary>
        /// <param name="center">圆心</param>
        /// <param name="radius">半径</param>
        /// <returns></returns>
        public static Vector2 GetRandomPointInCircle(Vector2 center, float radius)
        {
            return center + radius * Random.insideUnitCircle;
        }

        public static Vector2 GetRandomPointOnCircle(Vector2 center, float radius)
        {
            float angle = Random.Range(0f, Mathf.PI * 2f);
            return radius * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) + center;
        }

        /// <summary>
        /// 返回包围盒中的随机点
        /// </summary>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public static Vector2 GetRandomPointInBounds(Bounds bounds)
        {
            return (Vector2)bounds.center + new Vector2(Random.Range(-bounds.extents.x, bounds.extents.x), Random.Range(-bounds.extents.y, bounds.extents.y));
        }

        /// <summary>
        /// 返回碰撞体区域中的随机点
        /// </summary>
        /// <param name="collider2D"></param>
        /// <returns></returns>
        public static Vector2 GetRandomPointInCollider(Collider2D collider2D)
        {
            if (collider2D is BoxCollider2D boxCollider2D)
                return GetRandomPointInBoxCollider(boxCollider2D);
            if (collider2D is CircleCollider2D circleCollider2D)
                return GetRandomPointInCircleCollider(circleCollider2D);
            return GetRandomPointOverlapCollider(collider2D);
        }

        /// <summary>
        /// 返回BoxCollider区域中的随机点
        /// </summary>
        /// <param name="collider2D"></param>
        /// <returns></returns>
        public static Vector2 GetRandomPointInBoxCollider(BoxCollider2D collider2D)
        {
            Vector2 boxExtents = collider2D.size / 2f;
            return new Vector2(Random.Range(-boxExtents.x, boxExtents.x), Random.Range(-boxExtents.y, boxExtents.y)) + (Vector2)collider2D.transform.position;
        }

        /// <summary>
        /// 返回圆形碰撞体区域中的随机点
        /// </summary>
        /// <param name="collider2D"></param>
        /// <returns></returns>
        public static Vector2 GetRandomPointInCircleCollider(CircleCollider2D collider2D)
        {
            return collider2D.radius * Random.insideUnitCircle + collider2D.offset + (Vector2)collider2D.transform.position;
        }

        /// <summary>
        /// 通过随机生成点并判断返回碰撞体范围内的点
        /// </summary>
        /// <param name="collider2D"></param>
        /// <returns></returns>
        public static Vector2 GetRandomPointOverlapCollider(Collider2D collider2D)
        {
            int TryCount = 100;
            while (TryCount-- > 0)
            {
                Vector2 point = GetRandomPointInBounds(collider2D.bounds);
                if (collider2D.OverlapPoint(point))
                    return point;
            }
            return collider2D.transform.position;
        }
        #endregion
    }
}
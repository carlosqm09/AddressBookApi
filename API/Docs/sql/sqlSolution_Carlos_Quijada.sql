SELECT rv.name AS "name",
       b.title AS "title",
       r.rating AS "rating",
       r.rating_date AS "rating_date"
FROM ratings r
JOIN reviewers rv ON r.reviewer_id = rv.id
JOIN books b ON r.book_id = b.id
ORDER BY rv.name, b.title, r.rating DESC;


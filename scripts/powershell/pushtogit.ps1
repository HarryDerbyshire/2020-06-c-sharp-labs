function pushtogit {
    git add .
    git commit -m "Updating GitHub"
    git push
}

pushtogit $args[0]
